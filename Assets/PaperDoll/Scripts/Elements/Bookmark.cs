using UnityEngine;
using UnityEngine.EventSystems;

public class Bookmark : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int num;

    public void OnPointerDown(PointerEventData eventData)
    {
        Book.ST.PageActivate(num);
    }
}
