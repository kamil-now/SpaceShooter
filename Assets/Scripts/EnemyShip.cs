using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private GameObject target;
    private float missileVelocity = 10;
    private float turn = 1;
    private new Rigidbody rigidbody;
    private Vector3 torque;
    [SerializeField]
    private int speed;
    public float distance;
    private bool targetLock;
    private void Awake()
    {
        if (target == null)
        {
            target = GameManager.Instance.Player;
        }
        rigidbody = this.GetComponent<Rigidbody>();
        if (speed == 0)
            speed = Constants.DefaultEnemyShipSpeed;


    }
    public void Start()
    {
        targetLock = true;
    }
    private void FixedUpdate()
    {
        if (targetLock)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 0.3f * speed * Time.deltaTime);
        }
        transform.position += transform.forward * Time.deltaTime * speed;
        ScanForPlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
        }
    }

    private void ScanForPlayer()
    {
        distance = Vector3.Distance(this.transform.position, target.transform.position);
        if(distance<6)
        {
            targetLock = false;
        }
    }
}

