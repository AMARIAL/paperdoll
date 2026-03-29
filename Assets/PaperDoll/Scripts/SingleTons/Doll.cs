using UnityEngine;
using UnityEngine.UI;

public class Doll : MonoBehaviour
{
    public static Doll ST {get; private set;}

    [SerializeField] private Image shadow;
    [SerializeField] private Image blush;
    [SerializeField] private Image lips;

    private Sprite shadowSprite;
    private Sprite blushSprite;
    private Sprite lipsSprite;

    private void Awake()
    {
        if (ST != null)
        {
            Destroy(gameObject); 
            return;
        }
        ST = this;  
    }

    private void Start()
    {
        lipsSprite = lips.sprite;
        shadowSprite = shadow.sprite;
        blushSprite = blush.sprite;
    }

    public void ChangeLips(Sprite newSprite)
    {
        lips.sprite = newSprite;
    }
    public void ChangeBlush(Sprite newSprite)
    {
        blush.sprite = newSprite;
    }
    public void ChangeShadow(Sprite newSprite)
    {
        shadow.sprite = newSprite;
    }

    public void Reset()
    {
        lips.sprite = lipsSprite;
        shadow.sprite = shadowSprite;
        blush.sprite = blushSprite;
    }
}
