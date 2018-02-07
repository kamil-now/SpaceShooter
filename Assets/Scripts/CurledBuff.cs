using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurledBuff : MonoBehaviour
{
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
        transform.parent = GameManager.Instance.Player.transform;
        StartCoroutine(DisableBuff());
    }

    void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        time += Time.deltaTime;
        if (time >= rateOfFire)
        {
            bullet = Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
            bullet.GetComponentInChildren<Rigidbody>().velocity = transform.forward * 6;
            time = 0;
        }
    }

    private IEnumerator DisableBuff()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
