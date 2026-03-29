using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public static Hand ST {get; private set;}

    [SerializeField] private bool isActive;
    [SerializeField] private Vector3 zeroPosition;
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Sprite handOff;
    [SerializeField] private Sprite handOn;
    
    private Transform taken;
    private Vector3 takenPosition;
    private Transform itemOriginalParent;
    private Image image;
    private bool isBusy = false;
    
    private void Awake()
    {
        if (ST != null)
        {
            Destroy(gameObject);
            return;
        }
        ST = this;
        image = GetComponent<Image>();
        transform.position = basePosition; 
    }
    public void Take(Transform tf, ITarget target = null)
    {
        Cursor.ST.Switch();
        taken = tf;
        takenPosition = tf.position;
        itemOriginalParent = taken.parent;
        transform.DOMove(taken.position, 1f).SetEase(Ease.OutCubic).OnComplete(()=>PickUp(target));
    }
    public void Shake(Transform tf, bool isPut, ITarget target = null)
    {   
        Cursor.ST.Switch();
        transform.DOMove(tf.position, 1f).SetEase(Ease.OutCubic).OnComplete(()=>Action(isPut, target));
    }
    private void PickUp(ITarget target = null)
    {
        taken.SetParent(transform);
        image.sprite = handOn;
        isBusy = true;
        if(target != null)
            target.Action();
        else
            Move(zeroPosition);
    }
    private void Put (Vector2 pos, ITarget target = null)
    {
        taken.position = takenPosition;
        taken.SetParent(itemOriginalParent);
        taken = null;
        isBusy = false;
        image.sprite = handOff;
        Move(basePosition, false, target);
    }
    private void Move (Vector3 pos, bool isPut = false, ITarget target = null)
    {
        transform.DOMove(pos, 1f).SetEase(Ease.OutCubic).OnComplete(()=>
        {
            if(isPut)
                Put(pos, target);
            else
                target?.Done();
        });
    }
    private void Action(bool isPut, ITarget target = null)
    {
        transform.DOShakePosition(
            duration: 1.0f,
            strength: new Vector3(30f, 0, 0),
            vibrato: 10,
            randomness: 0,
            snapping: false,
            fadeOut: false
        ).OnComplete(()=>
        {
            Move(isPut ? takenPosition : zeroPosition, isPut, target);
            target?.Action();
        });
    }
}
