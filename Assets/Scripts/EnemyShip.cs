using System;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private GameObject target;
    private float missileVelocity =10;
    private float turn = 1;
    private new Rigidbody rigidbody;
    private Vector3 torque;
    [SerializeField]
    private int speed;

    private void  Awake()
    {
        if(target==null)
        {
            target = GameManager.Instance.Player;
        }
        rigidbody = this.GetComponent<Rigidbody>();
        if (speed == 0)
            speed = Constants.DefaultEnemyShipSpeed;
        
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        //SetTorque();

    }
    public Quaternion rot;
    private void FixedUpdate()
    {

       this.rigidbody.velocity = transform.forward;// * missileVelocity;

        var targetRotation = Quaternion.LookRotation(target.transform.position - this.transform.position);
        var rot = new Quaternion(targetRotation.x, targetRotation.y, targetRotation.z, targetRotation.w);
        rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));

    }
    private void SetTorque()
    {
        torque.x = 0;
        torque.y = 0;
        torque.z = 10;
        this.GetComponent<ConstantForce>().torque = torque;
    }
    private void ScanForPlayer()
    {

    }
}

