using UnityEngine;
using UnityEngine.EventSystems;

public class Shadow : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        Book.ST.TakeShadow(sprite);
    }
}
