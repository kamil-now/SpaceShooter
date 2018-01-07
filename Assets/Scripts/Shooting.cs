using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject ammoPrefab;
    private float time;
    private GameObject bulletsSpawn;
    private GameObject bullet;
    private float bulletSpeed;
    [SerializeField]
    private float rateOfFire;

    #region MonoBehaviour
    private void Start()
    {
        bulletsSpawn = Instantiate(new GameObject("BulletsSpawn"));
        if (bulletSpeed <= 0)
            bulletSpeed = Constants.DefaultBulletSpeed;
        if (rateOfFire <= 0)
            rateOfFire = Constants.DefaultRateOfFire;

    }

    private void Update()
    {
        if (ammoPrefab == null)
            ammoPrefab = DefaultPrefabs.Instance.DefaultBullet;
        time += Time.deltaTime;
        if (Input.GetKey("space") && time >= rateOfFire)
        {
            bullet = Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), ammoPrefab.transform.rotation);
            bullet.transform.SetParent(bulletsSpawn.transform);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);

            time = 0;
        }
    }
    #endregion
}

