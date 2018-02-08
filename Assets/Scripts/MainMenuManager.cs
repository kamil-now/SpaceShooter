using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(Values.MainSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
