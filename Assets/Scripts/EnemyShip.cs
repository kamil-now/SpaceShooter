using UnityEngine;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour
{
    private Transform target;
    private new Rigidbody rigidbody;
    [SerializeField]
    private int speed;
    private bool targetLock;
    private float distanceToTarget;
    [SerializeField]
    private int hp;
    private Text hpText;

    public int Hp
    {
        get
        {
            return hp;
        }
    }
    public float frequency;
    private float startTime;
    private Vector3 direction;
    private Vector3 orthogonal;
    private void Awake()
    {
        if (target == null)
        {
            target = GameManager.Instance.Player.transform;
        }
        rigidbody = this.GetComponent<Rigidbody>();
        speed = Constants.DefaultEnemyShipSpeed;
    }
    public void Start()
    {
        startTime = Time.time;
        hp = Constants.InitEnemyHp;
        hpText = GameManager.Instance.GetChildObject(this.transform, "HpText").GetComponent<Text>();

        targetLock = true;
    }
    private void FixedUpdate()
    {

        if (targetLock)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 0.2f * speed * Time.deltaTime);
        }


        transform.position += transform.forward * Time.deltaTime * speed;
        MeasureDistanceToTarget();

    }
    private void LateUpdate()
    {
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            Instantiate(DefaultPrefabs.Instance.EnemyExplosionVFX, transform.GetChild(0).transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            ScoreManager.Instance.Score += 1;
            hp--;

            if (hp == 0)
            {
                ScoreManager.Instance.Score += 10;
            }
            else
            {
                Instantiate(DefaultPrefabs.Instance.AsteroidExplosionVFX, transform.GetChild(0).transform.position, transform.rotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if (collision.gameObject.tag == "Player")
        {
            hp = 0;
        }
    }
    private void MeasureDistanceToTarget()
    {
        if (target != null && this != null)
        {
            distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
            if (distanceToTarget < 6)
            {
                targetLock = false;
            }
        }
    }
}

