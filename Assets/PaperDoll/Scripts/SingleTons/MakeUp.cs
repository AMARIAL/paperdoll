using UnityEngine;

public class MakeUp : MonoBehaviour
{
    public static MakeUp ST {get; private set;}

    [SerializeField] private Transform Cream;
    [SerializeField] private Transform Loofah;
    
    [SerializeField] private Transform Hand;
    
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
        Invoke(nameof(Starter), 1f);
    }

    private void Starter()
    {
        Cursor.ST.DoTap(Cream.position);
    }
}
