using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    private RectTransform rt;
    private Transform canvas;
    private Text text;
    private int randomNumber;
    private Transform player;

    private void Start()
    {
        canvas = transform.GetChild(0);
        text = canvas.GetChild(0).GetComponent<Text>();
        rt = canvas.GetComponent<RectTransform>();
        randomNumber = Random.Range(0, 11);
        text.text = randomNumber.ToString();
        canvas.SetParent(null);
        if(GameManager.Instance.Player != null)
        player = GameManager.Instance.Player.transform;
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
            Destroy(canvas.gameObject);
        }
    }
    //other collisions
    private void OnTriggerEnter(Collider other)
    {

        // GameObject asteroid = DefaultPrefabs.Instance.GetRandomMediumAsteroid();
        //AsteroidGenerator.Instance.Shatter(asteroid, transform.position, 2);
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            
            if (player.GetChild(1).GetChild(1).GetChild(player.GetComponent<PlayerShip>().randomOperation).name == randomNumber.ToString())
            {
                ScoreManager.Instance.Score += 3;
                player.GetChild(1).GetChild(0).GetComponent<Text>().text = (ScoreManager.Instance.Score + 3).ToString();
                player.GetComponent<PlayerShip>().GetRandomOperation();
            }
            else
            {
                Destroy(other.gameObject);
                player.transform.GetComponent<PlayerShip>().Hp -= 3;
                Destroy(this.gameObject);
                Destroy(canvas.gameObject);
                player.GetComponent<PlayerShip>().GetRandomOperation();
            }
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
        //Destroy(canvas.gameObject);
    }
    public void InstantiateExplosionParticle()
    {
        GameObject particle = Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.position, transform.rotation);
    }

}


