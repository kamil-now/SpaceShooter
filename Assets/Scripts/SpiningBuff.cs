using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningBuff : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
	private float rotateSpeed = 2;
    [SerializeField]
    private float rateOfFire;
    private float time;
    private GameObject bullet;

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        time += Time.deltaTime;
        if (time >= rateOfFire)
        {
            print("sasa");
            bullet = Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = transform.forward * 6;
            time = 0;
        }
    }
}
