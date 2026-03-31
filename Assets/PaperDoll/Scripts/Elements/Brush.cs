using UnityEngine;
using UnityEngine.EventSystems;

public enum BrushType : byte { Blush, Shadow }

public class Brush : MonoBehaviour, IPointerDownHandler, ITarget
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private BrushType type;
    [SerializeField] public Sprite sprite;
    private bool isTaked;
    private Sprite spriteNew;
    private Transform colorTransform;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isActive || isTaked) return;
        Hand.ST.Take(transform, this, true);
        isActive = false;
    }

    public void TakeBrush(Transform colorTf)
    {
        Hand.ST.Take(transform, this, false);
        colorTransform = colorTf;
    }
    public void PickUped()
    {
        MakeUp.ST.ChangeState(type == BrushType.Blush ? MakeUpState.Blush : MakeUpState.Shadow);
        if(colorTransform)
            Hand.ST.Shake(colorTransform, true);
    }

    public void Shaked()
    {
        if (spriteNew != null)
        {
            sprite = spriteNew;
            spriteNew = null;
        }
        else
        {
            if(type==BrushType.Blush)
                Doll.ST.ChangeBlush(sprite);
            else
                Doll.ST.ChangeShadow(sprite);  
        }
    }

    public void Puted()
    {
        colorTransform = null;
    }

    public void Moved()
    {
        
    }

    public void ChangeColor(Sprite sprite)
    {
        spriteNew = sprite;
    }
}
