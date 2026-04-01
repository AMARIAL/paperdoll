using UnityEngine;
using UnityEngine.EventSystems;

public class Loofah : MonoBehaviour, IPointerDownHandler, ITarget
{

    private bool isActive;
    private bool isTaked;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive || isTaked || !MakeUp.ST.IsState(MakeUpState.None)) return;
        Hand.ST.Take(transform, this, false);
        isActive = false;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void PickUped()
    {
        MakeUp.ST.ChangeState(MakeUpState.Loofah);
        Hand.ST.Shake(Face.ST.transform.position,false);
        isTaked = true;
    }
    public void Shaked()
    {
        Doll.ST.Reset();
    }
    public void Puted()
    {
        MakeUp.ST.ChangeState(MakeUpState.None);
        isTaked = false;
    }
    public void Moved()
    {
        isActive = true;
    }
}
