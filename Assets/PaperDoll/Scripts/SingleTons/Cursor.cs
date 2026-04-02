using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum CursorState: byte {None, Tap, DragDrop} 
public class Cursor : MonoBehaviour
{
    
    public static Cursor ST {get; private set;}

    [SerializeField] private bool isActive = false;
    [SerializeField] private CursorState currentState = CursorState.None;
    
    private Image image;
    private Sequence seq;
    private void Awake()
    {
        if (ST != null)
        {
            Destroy(gameObject);
            return;
        }
        ST = this;
        image = GetComponent<Image>();
        image.raycastTarget = false;
    }

    private void Start()
    {
        Switch();
    }

    public void DoTap (Vector2 pos)
    {
        Switch(true, CursorState.Tap);
        transform.position = pos;
        transform.DOScale(0.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void DoDragDrop(Transform tr1, Transform tr2)
    {
        Switch(true, CursorState.DragDrop);
        PlayCycle(tr1, tr2);
    }

    private void PlayCycle(Transform tr1, Transform tr2)
    {
        transform.position = tr1.position;
        transform.DOKill();
        seq = DOTween.Sequence();
        seq.Append(transform.DOScale(0.5f, 0.5f).SetLoops(1, LoopType.Yoyo));
        seq.Append(transform.DOMove(tr2.position, 1f).SetEase(Ease.Linear)); 
        seq.Append(transform.DOScale(0.6f, 0.5f).SetLoops(1, LoopType.Yoyo).OnComplete(() =>
        {
            PlayCycle(tr1, tr2);
        }));
    }

    public void Switch(bool flag = false, CursorState state = CursorState.None)
    {
        transform.DOKill();
        currentState = state;
        isActive = image.enabled = flag;
    }
}
