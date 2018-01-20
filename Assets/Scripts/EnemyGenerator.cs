using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyGenerator : MonoBehaviour
{
    private static EnemyGenerator instance;
    public static EnemyGenerator Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private bool on;
    [SerializeField]
    private float spawnWait;
    [SerializeField]
    private float startWait;
    [SerializeField]
    private float waveWait;
    

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
        if (enemyPrefab == null)
            enemyPrefab = DefaultPrefabs.Instance.DefaultEnemy;

        StartCoroutine(SpawnWaves());
        if (System.Math.Abs(spawnWait) < 0.1)
            spawnWait = Constants.AsteroidSpawnWait;
        if (System.Math.Abs(startWait) < 0.1)
            startWait = Constants.AsteroidStartWait;
        if (System.Math.Abs(waveWait) < 0.1)
            waveWait = Constants.AsteroidWaveWait;
        
    }
    #endregion

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (on)
            {
                Instantiate(enemyPrefab);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    
    private void Instantiate(GameObject prefab)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(GameManager.Instance.LeftBorder, GameManager.Instance.RightBorder), Constants.AsteroidSpawnPosition.y, Constants.AsteroidSpawnPosition.z);

        Instantiate(prefab, spawnPosition, prefab.transform.rotation);
    }
}
