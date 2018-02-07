using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AsteroidGenerator : MonoBehaviour
{
    private static AsteroidGenerator instance;
    public static AsteroidGenerator Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField]
    private GameObject[] asteroids;
    [SerializeField]
    private bool on;
    [SerializeField]
    private int asteroidCount;
    [SerializeField]
    private float spawnWait;
    [SerializeField]
    private float startWait;
    [SerializeField]
    private float waveWait;
    [SerializeField]
    private int speed;
    Vector3 torque;



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
        asteroids = DefaultPrefabs.Instance.BigAsteroids;
        spawnWait = Values.AsteroidSpawnWait;
        startWait = Values.AsteroidStartWait;
        waveWait = Values.AsteroidWaveWait;
        speed = Values.DefaultAsteroidSpeed;

        StartCoroutine(SpawnWaves());
    }
    #endregion
    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            if (on)
            {
                for (int i = 0; i < asteroidCount; i++)
                {
                    Instantiate(asteroids[Random.Range(0, asteroids.Length)]);

                    yield return new WaitForSeconds(spawnWait);
                }
            }

            yield return new WaitForSeconds(waveWait);
        }
    }
    public void Shatter(GameObject prefab, Vector3 spawnPosition, int asteroidCount)
    {
        StartCoroutine(Instantiate(prefab, asteroidCount, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z)));
    }

    private void Instantiate(GameObject asteroid)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(GameManager.Instance.LeftBorder, GameManager.Instance.RightBorder), Values.AsteroidSpawnPosition.y, Values.AsteroidSpawnPosition.z);
        GameObject temp = Instantiate(asteroid, spawnPosition, Quaternion.identity);

        torque.x = Random.Range(-1, 1);
        torque.y = Random.Range(-1, 1);
        torque.z = Random.Range(-1, 1);
        temp.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        temp.GetComponent<ConstantForce>().torque = torque;
    }
    private IEnumerator Instantiate(GameObject asteroid, int count, Vector3 spawnPosition)
    {
        for (int i = count; i > 0; i--)
        {
            GameObject temp = Instantiate(asteroid, spawnPosition, Quaternion.identity);

            torque.x = Random.Range(-0.5f, 0.5f);
            torque.y = Random.Range(-0.5f, 0.5f);
            torque.z = Random.Range(-0.5f, 0.5f);
            temp.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-2f, 2f), 0, -speed);
            temp.GetComponent<ConstantForce>().torque = torque;
            yield return new WaitForSeconds(0f);
        }
    }

}
