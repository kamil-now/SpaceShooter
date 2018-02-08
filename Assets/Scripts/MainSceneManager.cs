using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    private void Start()
    {
        if (Camera.main == null)
        {
            Debug.Log("no camera");
        }
        GameManager.Instance.PauseMenu =  GameObject.FindGameObjectWithTag("PauseMenu");
       
        GameManager.Instance.OnSceneLoaded(Camera.main);
    }
    public void Restart()
    {
        GameManager.Instance.Restart();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        GameManager.Instance.Continue();
    }
}

