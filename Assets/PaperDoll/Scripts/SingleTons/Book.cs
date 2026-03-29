using UnityEngine;

public class Book : MonoBehaviour
{
    public static Book ST {get; private set;}

    [SerializeField] private GameObject pagesLock;
    [SerializeField] private Transform bookMarks;
    [SerializeField] private GameObject[] pages = new GameObject[3];
    
    private GameObject[] marks;
    private bool isActive = true;

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
        marks = new GameObject[bookMarks.childCount];
        for (int i = 0; i < bookMarks.childCount; i++)
            marks[i] = bookMarks.GetChild(i).gameObject;
        
        PageActivate(0);
        isActive = false;
    }
    public void Activate ()
    {
        isActive = true;
        pagesLock.SetActive(false);
    }
    public void PageActivate(int num)
    {
        if(!isActive) return;
        
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[num].SetActive(true);
        BookMarksActivate(num);
    }

    private void BookMarksActivate(int num)
    {
        for (int i=0; i < marks.Length; i++)
        {
            marks[i].gameObject.SetActive(i % 2 == 0);
        }

        marks[num*2].gameObject.SetActive(false);
        marks[num*2+1].gameObject.SetActive(true);
    }

    public void TakeShadow(Sprite sprite)
    {
        
    }
    public void TakeBlush(Sprite sprite)
    {
        
    }
    public void TakeLipstick(Sprite sprite)
    {
        
    }
}
