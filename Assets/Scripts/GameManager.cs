using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public enum CameraShakeIntensity
    {
        Big,
        Medium,
        Small
    }
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private GameObject pauseMenu;
    private GameObject player;
    private GameObject starField;
    private GameObject background;
    private GameObject canvas;
    private Camera mainCamera;
    private bool gameOver;
    [SerializeField]
    private float leftBorder;
    [SerializeField]
    private float rightBorder;
    [SerializeField]
    private float bottomBorder;
    [SerializeField]
    private float topBorder;

    private bool pause;

    public GameObject Player
    {
        get
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            return player;
        }
    }
    public GameObject StarField
    {
        get
        {
            if (starField == null)
            {
                starField = GameObject.FindGameObjectWithTag("StarField");
            }

            return starField;
        }
    }
    public GameObject Canvas
    {
        get
        {
            return canvas;
        }
    }
    public Camera MainCamera
    {
        get { return mainCamera; }
    }

    public float TopBorder
    {
        get
        {
            return topBorder;
        }
    }
    public float BottomBorder
    {
        get
        {
            return bottomBorder;
        }
    }
    public float RightBorder
    {
        get
        {
            return rightBorder;
        }
    }
    public float LeftBorder
    {
        get
        {
            return leftBorder;
        }
    }

    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }

    public GameObject PauseMenu
    {
        get
        {
            return pauseMenu;
        }

        set
        {
            pauseMenu = value;
        }
    }

    #region MonoBehaviour
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SceneManager.LoadSceneAsync(Values.MainMenuIndex);

    }
    private void Update()
    {
        if (!pause)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            pause = true;
            PauseMenu.SetActive(true);
        }
    }
    #endregion
    public void Continue()
    {
        pause = false;
        PauseMenu.SetActive(false);
    }
    public void Restart()
    {
        Continue();
        ScoreManager.Instance.Score = 0;
        SceneManager.LoadScene(Values.MainSceneIndex);
    }
    public void OnSceneLoaded(Camera mainCamera)
    {
        SetupCamera(mainCamera);
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        SetupBackground();
        SetupStarField();
        PauseMenu.SetActive(false);
    }
    public void ShakeCamera(CameraShakeIntensity shake)
    {
        float shakeFactor = 0;
        switch (shake)
        {
            case CameraShakeIntensity.Big:
                {
                    shakeFactor = 1f;
                    break;
                }
            case CameraShakeIntensity.Medium:
                {
                    shakeFactor = 0.85f;
                    break;
                }
            case CameraShakeIntensity.Small:
                {
                    shakeFactor = 0.7f;
                    break;
                }
        }
        mainCamera.gameObject.GetComponent<CameraShake>().Shake(shakeFactor);
    }
    public void SetGameOver()
    {
        gameOver = true;
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(Values.RestartTime);
        SceneManager.LoadScene(Values.MainMenuIndex);
    }
    private void SetupBackground()
    {
        background = GameObject.FindGameObjectWithTag("Background");
        background.transform.localScale = Values.StarfieldBackgroundRatio;
    }
    private void SetupStarField()
    {
        starField = GameObject.FindGameObjectWithTag("StarField");
        starField.transform.position = Values.InitStarfieldPosition;
        starField.transform.localScale = new Vector3(background.transform.localScale.x / Values.StarfieldBackgroundRatio.x,
                                                    background.transform.localScale.y / Values.StarfieldBackgroundRatio.y,
                                                    background.transform.localScale.z / Values.StarfieldBackgroundRatio.z);
    }

    private void SetupCamera(Camera cam)
    {
        this.mainCamera = cam;
        mainCamera.transform.rotation = Values.DefaultCameraRotation;
        mainCamera.transform.position = Values.DefaultCameraPosition;
        float playerSize = 2 * Player.GetComponent<MeshRenderer>().bounds.size.x;
        float distanceToCamera = Vector3.Distance(Player.transform.position, mainCamera.transform.position);

        bottomBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).z + playerSize;
        topBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).z - playerSize;
        leftBorder = -Values.StarfieldBackgroundRatio.x / 2f + playerSize;
        rightBorder = Values.StarfieldBackgroundRatio.x / 2f - playerSize;

    }
    public GameObject GetChildObject(Transform parent, string tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == tag)
            {
                return child.gameObject;
            }
            if (child.childCount > 0)
            {
                var obj = GetChildObject(child, tag);
                if (obj != null)
                    return obj;
            }
        }
        return null;
    }
}


