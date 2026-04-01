using UnityEngine;
using UnityEngine.EventSystems;

public class Cream : MonoBehaviour, IPointerDownHandler, ITarget
{

    [SerializeField] private bool isActive;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        
        Hand.ST.Take(transform, this);
        
        isActive = false;
    }
    
    public void PickUped()
    {
        MakeUp.ST.ChangeState(MakeUpState.Cream);
        Cursor.ST.DoDragDrop(transform, Face.ST.transform);
    }
    public void Shaked()
    {
        Face.ST.RemoveAcne();
    }
    public void Puted()
    {
        MakeUp.ST.ChangeState(MakeUpState.None);
    }
    public void Moved()
    {
        Book.ST.Activate();
    }



}
