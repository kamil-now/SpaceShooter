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
    //public Vector3 stageDimensions;

    public void OnSceneLoaded(Camera camera)
    {

        StarField starField = FindObjectOfType<StarField>();
        starField.transform.position = Constants.InitStarfieldPosition;
        //TODO camera
        float playerSize = 2*Player.GetComponent<MeshRenderer>().bounds.size.x;
        float distanceToCamera = Vector3.Distance(Player.transform.position, camera.transform.position);
        //stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        leftBorder = camera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + playerSize;
        rightBorder = camera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - playerSize;
        bottomBorder = camera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).z + playerSize;
        topBorder = camera.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).z - playerSize;
        //leftBorder = -stageDimensions.y + playerSize;
        //rightBorder = stageDimensions.y - playerSize;
        //bottomBorder = -stageDimensions.z + playerSize;
        //topBorder = stageDimensions.z- playerSize;
    }
}


