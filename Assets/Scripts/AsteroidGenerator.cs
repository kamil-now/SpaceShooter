﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AsteroidGenerator : MonoBehaviour
{
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
    private void Start()
    {
        if (asteroids == null)
            asteroids = DefaultPrefabs.Instance.Asteroids;

        StartCoroutine(SpawnWaves());
        if (System.Math.Abs(spawnWait) < 0.1)
            spawnWait = Constants.AsteroidSpawnWait;
        if (System.Math.Abs(startWait) < 0.1)
            startWait = Constants.AsteroidStartWait;
        if (System.Math.Abs(waveWait) < 0.1)
            waveWait = Constants.AsteroidWaveWait;
        if (speed == 0)
            speed = Constants.AsteroidDefaultSpeed;
    }
    #endregion
    //TODO 
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (on)
                for (int i = 0; i < asteroidCount; i++)
                {
                    GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(GameManager.Instance.LeftBorder, GameManager.Instance.RightBorder), Constants.AsteroidSpawnPosition.y, Constants.AsteroidSpawnPosition.z);

                    GameObject temp = Instantiate(asteroid, spawnPosition, Quaternion.identity);

                    torque.x = Random.Range(-1, 1);
                    torque.y = Random.Range(-1, 1);
                    torque.z = Random.Range(-1, 1);
                    temp.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed); //AddForce(0, 0, -1);
                    temp.GetComponent<ConstantForce>().torque = torque;

                    yield return new WaitForSeconds(spawnWait);
                }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
