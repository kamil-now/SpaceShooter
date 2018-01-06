using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //TODO enum rate of fire
    [SerializeField]
    private GameObject ammoPrefab;
    private float time;
    private GameObject bulletsSpawn;
    private GameObject bullet;
    //temp
    private int speed;
    //
    #region MonoBehaviour
    private void Start()
    {
        bulletsSpawn = Instantiate(new GameObject("BulletsSpawn"));
        //temp
        speed = 25;
        //
    }

    private void Update()
    {
        if (ammoPrefab == null)
            ammoPrefab = DefaultPrefabs.Instance.DefaultBullet;
        time += Time.deltaTime;
        if (Input.GetKey("space") && time >= 0.2f)
        {
            bullet = Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z+1), ammoPrefab.transform.rotation);
            bullet.transform.SetParent(bulletsSpawn.transform);
            //temp
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,0, speed);
            //
            time = 0;
        }
    }
    #endregion
}

