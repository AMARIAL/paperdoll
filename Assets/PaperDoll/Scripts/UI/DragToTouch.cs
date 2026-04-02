using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.EventSystems;

public class DragToTouchSmooth : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private float moveDuration = 0.25f; // для тапа
    [SerializeField] private float followSmooth = 0.1f;  // для драга

    private Camera cam;
    private Tween currentTween;
    private RectTransform target;
    
    private void Awake()
    {
        cam = canvas.worldCamera;
    }

    private void Start()
    {
        target = Hand.ST.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(!Hand.ST.isReady) return;
        
        HandleTouch();
        HandleMouse(); // для редактора
    }

    private void HandleTouch()
    {
        if (Touchscreen.current == null)
            return;

        var touch = Touchscreen.current.primaryTouch;

        if (!touch.press.isPressed)
            return;

        Vector2 screenPos = touch.position.ReadValue();
        Vector2 localPos = ScreenToCanvas(screenPos);

        if (touch.press.wasPressedThisFrame)
        {
            MoveTo(localPos);
        }
        else
        {
            Follow(localPos);
        }
    }

    private void HandleMouse()
    {
        if (Mouse.current == null)
            return;

        if (!Mouse.current.leftButton.isPressed)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 localPos = ScreenToCanvas(screenPos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            MoveTo(localPos);
        }
        else
        {
            Follow(localPos);
        }
    }

    private Vector2 ScreenToCanvas(Vector2 screenPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPos,
            cam,
            out Vector2 localPoint
        );

        return localPoint;
    }

    private void MoveTo(Vector2 pos)
    {
        currentTween?.Kill();

        currentTween = target
            .DOAnchorPos(pos, moveDuration)
            .SetEase(Ease.OutQuad).OnComplete(()=>CheckFace());
    }

    private void Follow(Vector2 pos)
    {
        currentTween?.Kill();

        currentTween = target
            .DOAnchorPos(pos, followSmooth)
            .SetEase(Ease.OutQuad).OnComplete(()=>CheckFace());
    }

    private void CheckFace()
    {
        if (!IsOverlap(target, Face.ST.faceRect)) return;
        
        Face.ST.OnPointerDown(new PointerEventData(EventSystem.current));
    }
    private static bool IsOverlap(RectTransform a, RectTransform b)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(
            a, b.position, null
        ) || RectTransformUtility.RectangleContainsScreenPoint(
            b, a.position, null
        );
    }
}