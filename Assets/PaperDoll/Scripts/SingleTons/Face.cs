using UnityEngine;
using UnityEngine.EventSystems;

public class Face : MonoBehaviour, IPointerDownHandler
{
    public static Face ST {get; private set;}


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
        
    }
    
}
