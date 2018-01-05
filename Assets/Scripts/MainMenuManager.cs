﻿using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{


    public void ChangeScene()
    {
        SceneManager.LoadScene(Constants.MainSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
