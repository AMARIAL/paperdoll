using UnityEngine;
using UnityEngine.EventSystems;

public class Loofah : MonoBehaviour, IPointerDownHandler, ITarget
{

    [SerializeField] private bool isActive;
    private bool isTaked;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        Hand.ST.Take(transform, this);
        isActive = false;
    }

    public void Action()
    {
        if(isTaked)
        {
            Doll.ST.Reset();
        }
        else
        {
            Hand.ST.Shake(Face.ST.transform,true, this);
            isTaked = true;
        }
    }

    public void Done()
    {
        isTaked = false;
        isActive = true;
    }
}
