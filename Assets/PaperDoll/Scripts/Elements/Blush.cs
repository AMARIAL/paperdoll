using UnityEngine;
using UnityEngine.EventSystems;

public class Blush : MonoBehaviour, IPointerDownHandler, ITarget
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Book.ST.TakeBlush(sprite);
    }

    public void PickUped()
    {
        
    }

    public void Shaked()
    {
        Doll.ST.ChangeLips(sprite);
    }

    public void Puted()
    {
        
    }

    public void Moved()
    {
        
    }
}
