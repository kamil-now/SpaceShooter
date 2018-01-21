using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBuff : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private LineRenderer laserLine;

    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetWidth(.4f, .4f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
            endPoint = hit.point;
        startPoint = transform.parent.position;
        laserLine.SetPosition(0, startPoint);
        laserLine.SetPosition(1, endPoint);
    }
}
