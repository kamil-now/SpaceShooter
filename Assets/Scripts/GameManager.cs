using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private GameObject player;
    private GameObject starField;
    private GameObject background;
    private GameObject canvas;
    private Camera mainCamera;

    [SerializeField]
    private float leftBorder;
    [SerializeField]
    private float rightBorder;
    [SerializeField]
    private float bottomBorder;
    [SerializeField]
    private float topBorder;

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
        SceneManager.LoadSceneAsync(Constants.MainSceneIndex);

    }
    #endregion

    public void OnSceneLoaded(Camera mainCamera)
    {
        SetupCamera(mainCamera);
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        SetupBackground();
        SetupStarField();

    }
    public void ShakeCamera()
    {
        mainCamera.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;
    }
    public void GameOver()
    {
        StartCoroutine( ReloadScene()) ;
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(Constants.RestartTime);
        SceneManager.LoadSceneAsync(Constants.MainSceneIndex);
    }
    private void SetupBackground()
    {
        background = GameObject.FindGameObjectWithTag("Background");
    }
    private void SetupStarField()
    {
        starField = GameObject.FindGameObjectWithTag("StarField");
        starField.transform.position = Constants.InitStarfieldPosition;
        starField.transform.localScale = new Vector3(background.transform.localScale.x / Constants.StarfieldBackgroundRatio.x,
                                                    background.transform.localScale.y / Constants.StarfieldBackgroundRatio.y,
                                                    background.transform.localScale.z/Constants.StarfieldBackgroundRatio.z);
    }

    private void SetupCamera(Camera cam)
    {
        this.mainCamera = cam;
        mainCamera.transform.rotation = Constants.DefaultCameraRotation;
        mainCamera.transform.position = Constants.DefaultCameraPosition;
        float playerSize = 2 * Player.GetComponent<MeshRenderer>().bounds.size.x;
        float distanceToCamera = Vector3.Distance(Player.transform.position, mainCamera.transform.position);
        //stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //leftBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + playerSize;
        //rightBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - playerSize;
        bottomBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).z + playerSize;
        topBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).z - playerSize;
        leftBorder = -Constants.StarfieldBackgroundRatio.x / 2f + playerSize;
        rightBorder = Constants.StarfieldBackgroundRatio.x / 2f - playerSize;

    }

}


