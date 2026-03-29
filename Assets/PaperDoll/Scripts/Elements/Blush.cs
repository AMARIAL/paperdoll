using UnityEngine;
using UnityEngine.EventSystems;

public class Blush : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        Book.ST.TakeBlush(sprite);
    }
}
