using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Face : MonoBehaviour, IPointerDownHandler
{
    public static Face ST {get; private set;}

    [SerializeField] private Transform lips;
    [SerializeField] private Transform shadow;
    [SerializeField] private Transform blush;
    [SerializeField] private Image acne;
    
    private void Awake()
    {
        if (ST != null)
        {
            Destroy(gameObject);
            return;
        }
        ST = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!Hand.ST.taken) return;
        
        if (MakeUp.ST.IsState(MakeUpState.Cream))
        {
            Hand.ST.Shake(transform, false);
        }
        else if (MakeUp.ST.IsState(MakeUpState.Lips))
        {
            Hand.ST.Shake(lips, false);
        }
        else if (MakeUp.ST.IsState(MakeUpState.Shadow))
        {
            Hand.ST.Shake(shadow, false);
        }
        else if (MakeUp.ST.IsState(MakeUpState.Blush))
        {
            Hand.ST.Shake(blush, false);
        }
    }

    public void RemoveAcne()
    {
        acne.enabled = false;
    }
}
