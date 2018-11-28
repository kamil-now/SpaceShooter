using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    private RectTransform rt;
    private Transform canvas;

    private void OnEnable()
    {
        canvas = transform.GetChild(0);
        Text text = canvas.GetChild(0).GetComponent<Text>();
        rt = canvas.GetComponent<RectTransform>();
        text.text = Random.Range(0, 10).ToString();
        canvas.SetParent(null);
    }

    private void Update()
    {
        rt.position = new Vector3(transform.position.x, 1, transform.position.z);

        if (System.Math.Abs(this.gameObject.transform.position.y) > 1)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
        }

    }
    //collision with player or enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    //other collisions
    private void OnTriggerEnter(Collider other)
    {

        if (this.gameObject.tag == "BigAsteroid")
        {
           // GameObject asteroid = DefaultPrefabs.Instance.GetRandomMediumAsteroid();
            //AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 2);
            if (other.gameObject.tag == "Bullet")
            {
                ScoreManager.Instance.Score += 1;
            }

        }
        else if (this.gameObject.tag == "MediumAsteroid")
        {
 
        }
        else if (this.gameObject.tag == "SmallAsteroid")
        {

        }
        if (!other.CompareTag("Enemy"))
        {
            Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(canvas.gameObject);
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Destroy(canvas.gameObject);
    }
    public void InstantiateExplosionParticle()
    {
        GameObject particle = Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
    }

    public void GetSmallAsteroid()
    {
        GameObject asteroid = DefaultPrefabs.Instance.GetRandomSmallAsteroid();
        AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 3);
    }

    public void GetMediumAsteroid()
    {
        GameObject asteroid = DefaultPrefabs.Instance.GetRandomMediumAsteroid();
        AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 2);
    }
}


