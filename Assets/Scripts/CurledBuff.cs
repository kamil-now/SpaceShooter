using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurledBuff : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
	private float rotateSpeed = 2;
    [SerializeField]
    private float rateOfFire;
    private float time;
    private GameObject bullet;

    private void Start()
    {
        StartCoroutine(DisableBuff());
    }
    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        time += Time.deltaTime;
        if (time >= rateOfFire)
        {
            bullet = Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = transform.forward * 6;
            time = 0;
        }
    }

    private IEnumerator DisableBuff()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
