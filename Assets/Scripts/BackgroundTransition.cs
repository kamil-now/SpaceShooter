using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransition : MonoBehaviour
{

    private float scrollSpeed = -0.1f;
    private float tileSizeZ = Constants.BackgroundLength;

    private Vector3 startPosition;
    
    void Awake()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

    }
}
