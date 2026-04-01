using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Face : MonoBehaviour, IPointerDownHandler
{
    public static Face ST {get; private set;}
    
    [SerializeField] private Image acne;
    [SerializeField] private float shadowOffset;
    [SerializeField] private float blushOffset;
    [SerializeField] private float lipsOffset;
    
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
        if(!Hand.ST.taken || MakeUp.ST.IsState(MakeUpState.None)) return;

        Vector3 pos = transform.position;
        
        if (MakeUp.ST.IsState(MakeUpState.Lips))
        {
            pos += Vector3.down * lipsOffset;
        }
        else if (MakeUp.ST.IsState(MakeUpState.Shadow))
        {
            pos += Vector3.down * shadowOffset;
        }
        else if (MakeUp.ST.IsState(MakeUpState.Blush))
        {
            pos += Vector3.down * blushOffset;
        }
        Hand.ST.Shake(pos, false);
    }

    public void RemoveAcne()
    {
        acne.enabled = false;
    }
}
