using UnityEngine;
using UnityEngine.EventSystems;

public class Cream : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private bool isActive;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive) return;
        
        Hand.ST.Take(transform);
        
        isActive = false;
    }
}
