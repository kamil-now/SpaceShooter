using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void ChangeScene()
    {
        SceneManager.LoadScene(Constants.MainSceneIndex);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
