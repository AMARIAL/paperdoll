using UnityEngine;
using UnityEngine.EventSystems;

public class Lipstick : MonoBehaviour, IPointerDownHandler, ITarget
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        //Book.ST.TakeLipstick(sprite);
        Hand.ST.Take(transform);
        isActive = false;
    }

    public void Action()
    {
        throw new System.NotImplementedException();
    }

    public void Done()
    {
        throw new System.NotImplementedException();
    }
}
