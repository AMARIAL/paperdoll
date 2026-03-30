using UnityEngine;
using UnityEngine.EventSystems;

public class Lipstick : MonoBehaviour, IPointerDownHandler, ITarget
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        Hand.ST.Take(transform, this, true);
        isActive = false;
    }

    public void PickUped()
    {
        MakeUp.ST.ChangeState(MakeUpState.Lips);
    }
    
    public void Shaked()
    {
        Doll.ST.ChangeLips(sprite);
    }
    public void Puted()
    {
        isActive = true;
    }

    public void Moved()
    {
        
    }
}
