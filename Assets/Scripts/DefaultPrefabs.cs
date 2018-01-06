using UnityEngine;

public class DefaultPrefabs : MonoBehaviour
{
    private static DefaultPrefabs instance;
    public static DefaultPrefabs Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField]
    private GameObject defaultBullet;
    [SerializeField]
    private GameObject defaultEnemy;
    [SerializeField]
    private GameObject defaultHpText;
    [SerializeField]
    private GameObject defaultHpObject;
    [SerializeField]
    private GameObject[] asteroids;
    public GameObject DefaultBullet
    {
        get
        {
            return defaultBullet;
        }
    }

    public GameObject DefaultEnemy
    {
        get
        {
            return defaultEnemy;
        }
    }
    

    public GameObject DefaultHpObject
    {
        get
        {
            return defaultHpObject;
        }
    }

    public GameObject DefaultHpText
    {
        get
        {
            return defaultHpText;
        }
    }

    public GameObject[] Asteroids
    {
        get
        {
            return asteroids;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}

