using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Done()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
