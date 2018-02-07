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
            Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
        }

    }
    //collision with player or enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
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
            {
                ScoreManager.Instance.Score += 1;
            }

        }
        else if (this.gameObject.tag == "MediumAsteroid")
        {
            GameObject asteroid = DefaultPrefabs.Instance.GetRandomSmallAsteroid();
            AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 2);
            if (other.gameObject.tag == "Bullet")
            {
                ScoreManager.Instance.Score += 2;
            }
        }
        else if (this.gameObject.tag == "SmallAsteroid")
        {
            if (other.gameObject.tag == "Bullet")
            {
                BuffGenerator.Instance.InstantiateBuff(transform.position);
                ScoreManager.Instance.Score += 3;
            }
                
        }
        Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void InstantiateExplosionParticle()
    {
        Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
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


