using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float tilt;
    private float horizontal;
    private float vertical;

    private new Rigidbody rigidbody;
    private Vector3 vector;

    #region MonoBehaviour
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = Values.DefaultPlayerSpeed;
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vector = new Vector3(horizontal, 0, vertical);

        rigidbody.velocity = vector * Time.fixedUnscaledDeltaTime * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, GameManager.Instance.LeftBorder, GameManager.Instance.RightBorder),
            Values.InitPlayerPosition.y,
            Mathf.Clamp(rigidbody.position.z, GameManager.Instance.BottomBorder, GameManager.Instance.TopBorder));

    }
    #endregion
}

