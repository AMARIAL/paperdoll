using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Done : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Transform rightShelf;
    [SerializeField] private Transform leftShelf;

    private Image image;
    private Button button;
    
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.enabled = false;
    }
    public void Activate()
    {
        image.sprite = sprite; 
        button.enabled = true;
    }
    public void DoneAction()
    {
        rightShelf.DOMove(Vector3.right*10f, 1f);
        leftShelf.DOMove(Vector3.left * 10f, 1f);
        Book.ST.transform.DOMove(Vector3.down*10f, 1f);
        Debug.Log("Готово!");
    }
    
}
