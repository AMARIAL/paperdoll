using UnityEngine;

public enum MakeUpState: byte {None, Cream, Loofah, Shadow, Blush, Lips} 
    
public class MakeUp : MonoBehaviour
{
    public static MakeUp ST {get; private set;}

    [SerializeField] private Transform cream;

    [SerializeField] private MakeUpState currentState;
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
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // отключает затухание экрана
        Invoke(nameof(Starter), 0.05f);
    }

    private void Starter()
    {
        ChangeState(MakeUpState.None);
        Cursor.ST.DoTap(cream.position);
    }

    public void ChangeState(MakeUpState state)
    {
        if(!IsState(state))
            currentState = state;
    }
    public bool IsState(MakeUpState state)
    {
        return currentState == state;
    }
}
