using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private Text hpText;

    private void Start()
    {
        hp = Constants.InitPlayerHp;
        hpText = GameManager.Instance.GetChildObject(this.transform, "HpText").GetComponent<Text>();
    }
    private void Update()
    {
        hpText.text = hp.ToString();
        if (hp <= 0)
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
                    hp -= 3;
                    shake = GameManager.CameraShakeIntensity.Big;
                    break;
                }
            case "MediumASteroid":
                {
                    hp -= 2;
                    shake = GameManager.CameraShakeIntensity.Medium;
                    break;
                }
            case "SmallAsteroid":
                {
                    hp--;
                    shake = GameManager.CameraShakeIntensity.Small;
                    break;
                }
            case "Enemy":
                {
                    hp -= 5;
                    shake = GameManager.CameraShakeIntensity.Big;
                    break;
                }
        }
        GameManager.Instance.ShakeCamera(shake);
    }
}

