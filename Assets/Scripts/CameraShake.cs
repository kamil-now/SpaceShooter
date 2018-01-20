using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Transform camTransform;

    private float shakeDuration;

    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

   private Vector3 originalPos;

    #region MonoBehaviour
    private void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
    #endregion
    public void Shake(float shakeFactor)
    {
        shakeDuration = 0.3f;
        shakeAmount = shakeFactor;
    }
}
