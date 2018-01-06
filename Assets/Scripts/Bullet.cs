using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);
            
            //TODO publish event
            ScoreManager.Instance.Score += 10;
            Destroy(gameObject);
        }
    }
}
