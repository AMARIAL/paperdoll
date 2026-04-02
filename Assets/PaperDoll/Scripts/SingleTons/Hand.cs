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
    
    public Transform taken;
    public Transform takenNew;
    private ITarget takenTarget;
    private Vector3 takenPosition;
    private Transform takenParent;
    private ITarget takenTargetNew;
    private bool isBusy;
    private Image image;
    public bool isReady;
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
    public void Take (Transform tf, ITarget target, bool isZeroPosition = true)
    {
        Cursor.ST.Switch();
        
        if(isBusy) return;

        isBusy = true;
        isReady = false;
        if (taken)
        {
            takenNew = tf;
            takenTargetNew = target;
            ChangeTarget(isZeroPosition);
            return;
        }
        
        taken = tf;
        takenTarget = target;
        takenPosition = taken.position;
        takenParent = taken.parent;
        transform.DOMove(taken.position, 1f).SetEase(Ease.OutCubic).OnComplete(()=>PickUp(isZeroPosition));
    }
    private void ChangeTarget(bool isZeroPosition = true)
    {
        transform.DOMove(takenPosition, 1f).SetEase(Ease.OutCubic).OnComplete(()=>Put(true, isZeroPosition));
    }
    public void Shake(Vector3 shakePlace, bool isZeroPosition)
    {
        Cursor.ST.Switch();
        if(isBusy) return;
        isBusy = true;
        isReady = false;
        transform.DOMove(shakePlace, 1f).SetEase(Ease.OutCubic).OnComplete(()=>Action(isZeroPosition));
    }
    private void PickUp(bool isZeroPosition = true)
    {
        taken.SetParent(transform);
        image.sprite = handOn;
        if (isZeroPosition)
            transform.DOMove(zeroPosition, 1f).SetEase(Ease.OutCubic).OnComplete(()=>{
                isBusy = false;
                isReady = true;
            });
        else
            isBusy = false;
        takenTarget?.PickUped();
    }
    private void Put (bool isChangeTarget = false, bool isZeroPosition = true)
    {
        taken.position = takenPosition;
        taken.SetParent(takenParent);
        taken = null;
        takenPosition = Vector3.zero;
        takenParent = null;
        image.sprite = handOff;
        isBusy = false;
        takenTarget?.Puted();
        if(isChangeTarget)
            Take(takenNew, takenTargetNew, isZeroPosition);
        else
            transform.DOMove(basePosition, 1f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                takenTarget?.Moved();
            });
    }
    
    private void Action(bool isZeroPosition)
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
            takenTarget?.Shaked();
            transform.DOMove(isZeroPosition ? zeroPosition : takenPosition, 1f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                if (!isZeroPosition)
                    Put();
                else
                {
                    isBusy = false;
                    isReady = true;
                }
                    
            });
        });
    }
}
