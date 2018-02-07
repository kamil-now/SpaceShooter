using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransition : MonoBehaviour
{

    private float scrollSpeed = -0.3f;
    private float tileSizeZ = Values.BackgroundLength;

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
