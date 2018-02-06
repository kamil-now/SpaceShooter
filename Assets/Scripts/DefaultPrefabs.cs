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
    private GameObject playerExplosionVFX;
    [SerializeField]
    private GameObject enemyExplosionVFX;
    [SerializeField]
    private GameObject asteroidExplosionVFX;
    [SerializeField]
    private GameObject[] smallAsteroids;
    [SerializeField]
    private GameObject[] mediumAsteroids;
    [SerializeField]
    private GameObject[] bigAsteroids;

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
    public GameObject PlayerExplosionVFX
    {
        get
        {
            return playerExplosionVFX;
        }
    }
    public GameObject EnemyExplosionVFX
    {
        get
        {
            return enemyExplosionVFX;
        }
    }
    public GameObject AsteroidExplosionVFX
    {
        get
        {
            return asteroidExplosionVFX;
        }
    }
    public GameObject[] SmallAsteroids
    {
        get
        {
            return smallAsteroids;
        }
    }
    public GameObject[] MediumAsteroids
    {
        get
        {
            return mediumAsteroids;
        }
    }
    public GameObject[] BigAsteroids
    {
        get
        {
            return bigAsteroids;
        }
    }

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject GetRandomSmallAsteroid()
    {
        return SmallAsteroids[Random.Range(0, SmallAsteroids.Length)];
    }
    public GameObject GetRandomMediumAsteroid()
    {
        return MediumAsteroids[Random.Range(0, MediumAsteroids.Length)];
    }
    public GameObject GetRandomBigAsteroid()
    {
        return BigAsteroids[Random.Range(0, BigAsteroids.Length)];
    }
}

