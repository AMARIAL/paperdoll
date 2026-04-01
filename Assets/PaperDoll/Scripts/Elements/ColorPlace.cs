using UnityEngine;
using UnityEngine.EventSystems;

public class ColorPlace : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        if (Hand.ST.taken)
        
            Hand.ST.Shake(transform.position + Vector3.down * 0.8f, true);
        else
            Book.ST.brush.TakeBrush(transform);
        
        Book.ST.brush.ChangeColor(sprite);
        
        isActive = false;
        Invoke(nameof(Activate), 1f);
    }

    private void Activate()
    {
        isActive = true;
    }
}
