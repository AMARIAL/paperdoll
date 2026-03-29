using UnityEngine;

public class MakeUp : MonoBehaviour
{
    public static MakeUp ST {get; private set;}

    [SerializeField] private Transform cream;
    [SerializeField] private Transform loofah;

    [SerializeField] private GameObject acne;
    [SerializeField] private GameObject pagesLock;
    
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
        Invoke(nameof(Starter), 0.1f);
    }

    private void Starter()
    {
        Cursor.ST.DoTap(cream.position);
    }

    public void RemoveAcne()
    {
        acne.SetActive(false);
        pagesLock.SetActive(false);
    }
}
