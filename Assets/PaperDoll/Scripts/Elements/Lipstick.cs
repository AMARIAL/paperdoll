using UnityEngine;
using UnityEngine.EventSystems;

public class Lipstick : MonoBehaviour, IPointerDownHandler, ITarget
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isTaked;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive || isTaked) return;
        Hand.ST.Take(transform, this, true);
        isActive = false;
        Invoke(nameof(Activate), 1f);
    }

    public void PickUped()
    {
        MakeUp.ST.ChangeState(MakeUpState.Lips);
        isTaked = true;
    }
    
    public void Shaked()
    {
        MakeUp.ST.ChangeState(MakeUpState.None);
        Doll.ST.ChangeLips(sprite);
    }
    public void Puted()
    {
        isTaked = false;
    }

    public void Moved()
    {
        isActive = true;
    }
    private void Activate()
    {
        isActive = true;
    }
}
