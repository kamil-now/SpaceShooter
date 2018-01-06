using Assets.Scripts;
using System;
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

    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        SceneManager.LoadSceneAsync(Constants.MainSceneIndex);

    }
    
    public void OnSceneLoaded(Camera mainCamera)
    {
        SetupCamera(mainCamera);
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        SetupStarField();
        
    }

    public void GameOver()
    {
        //TODO
        SceneManager.LoadSceneAsync(Constants.MainSceneIndex);
    }
    private void SetupStarField()
    {
        starField = GameObject.FindGameObjectWithTag("StarField");
        starField.transform.position = Constants.InitStarfieldPosition;
    }
    private void SetupCamera(Camera cam)
    {
        this.mainCamera = cam;
        mainCamera.transform.rotation = Constants.DefaultCameraRotation;
        mainCamera.transform.position = Constants.DefaultCameraPosition;
        float playerSize = 2 * Player.GetComponent<MeshRenderer>().bounds.size.x;
        float distanceToCamera = Vector3.Distance(Player.transform.position, mainCamera.transform.position);
        //stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
        leftBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + playerSize;
        rightBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - playerSize;
        bottomBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).z + playerSize;
        topBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).z - playerSize;
        //leftBorder = -stageDimensions.y + playerSize;
        //rightBorder = stageDimensions.y - playerSize;
        //bottomBorder = -stageDimensions.z + playerSize;
        //topBorder = stageDimensions.z- playerSize;

    }
    
}


