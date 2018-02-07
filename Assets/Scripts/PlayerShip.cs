using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private Text hpText;

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    private void Start()
    {
        Hp = Values.InitPlayerHp;
        hpText = GameManager.Instance.GetChildObject(this.transform, "HpText").GetComponent<Text>();
    }
    private void Update()
    {
        hpText.text = Hp.ToString();
        if (Hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(DefaultPrefabs.Instance.PlayerExplosionVFX, transform.position, transform.rotation);

            GameManager.Instance.GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.CameraShakeIntensity shake = GameManager.CameraShakeIntensity.Small;
        switch (collision.gameObject.tag)
        {
            case "BigAsteroid":
                {
                    Hp -= 3;
                    shake = GameManager.CameraShakeIntensity.Big;
                    break;
                }
            case "MediumASteroid":
                {
                    Hp -= 2;
                    shake = GameManager.CameraShakeIntensity.Medium;
                    break;
                }
            case "SmallAsteroid":
                {
                    Hp--;
                    shake = GameManager.CameraShakeIntensity.Small;
                    break;
                }
            case "Enemy":
                {
                    Hp -= 5;
                    shake = GameManager.CameraShakeIntensity.Big;
                    break;
                }
        }
        GameManager.Instance.ShakeCamera(shake);
    }
}

