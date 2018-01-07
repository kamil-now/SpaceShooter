using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Update()
    {
        if (System.Math.Abs(this.gameObject.transform.position.y) > 1)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }
    //collision with player object
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
    //other collisions
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "BigAsteroid")
        {
            GameObject asteroid = DefaultPrefabs.Instance.GetRandomMediumAsteroid();
            AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 2);
            if (other.gameObject.tag == "Bullet")
                ScoreManager.Instance.Score += 1;

        }
        else if (this.gameObject.tag == "MediumAsteroid")
        {
            GameObject asteroid = DefaultPrefabs.Instance.GetRandomSmallAsteroid();
            AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 3);
            if (other.gameObject.tag == "Bullet")

                ScoreManager.Instance.Score += 2;

        }
        else if (this.gameObject.tag == "SmallAsteroid")
        {
            if (other.gameObject.tag == "Bullet")

                ScoreManager.Instance.Score += 3;
        }

        Destroy(this.gameObject);
    }

}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Asteroid : MonoBehaviour
//{
//    private bool shattered;

//    public bool Shattered
//    {
//        get
//        {
//            return shattered;
//        }

//        set
//        {
//            shattered = value;
//        }
//    }
//    private void Update()
//    {
//        //Transform parent = this.gameObject.transform.parent;
//        //if (parent != null && !parent.GetComponent<Asteroid>().Shattered)
//        //{
//        //    transform.position = transform.parent.position;
//        //}
//        if (System.Math.Abs(this.gameObject.transform.position.y) > 1)
//        {
//            this.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
//        }

//    }
//    //    Asteroid logic for shattering on hit, 
//    //rename DDOL -> DontDestroyOnLoad,
//    //small and medium asterooid prefabs for testing
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            if (!shattered)
//            {
//                foreach (Transform child in this.gameObject.transform)
//                {
//                    Destroy(child);
//                }
//            }
//            Destroy(this.gameObject);
//        }

//    }
//    private void OnTriggerEnter(Collider other)
//    {

//        if (other.gameObject.tag == "Bullet")
//        {
//            if (this.gameObject.transform.parent == null)
//            {
//                if (this.transform.childCount == 0)
//                    ScoreManager.Instance.Score += 10;
//                Debug.Log("Destroy " + gameObject.name);
//                Destroy(this.gameObject);
//            }
//            else
//            {
//                Shatter();
//            }
//        }
//    }
//    private void Shatter()
//    {
//        Debug.Log("Shatter " + gameObject.name);
//        this.Shattered = true;

//        //children are by default kinematic to avoid colliding against each other
//        foreach (Transform child in this.gameObject.transform.parent)
//        {
//            Rigidbody rb = child.GetComponent<Rigidbody>();

//            //rb.transform.position = new Vector3(rb.transform.position.x, 0, rb.transform.position.z);
//            rb.isKinematic = false;
//            //TODO assign speed of parent
//            rb.velocity = new Vector3(0, 0, -1);
//        }
//        if (transform.parent != null)
//        {
//            transform.parent.DetachChildren();
//            Destroy(transform.parent);
//        }

//    }
//}


