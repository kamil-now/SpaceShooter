using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffIcoControl : MonoBehaviour {

	void Update () {
        transform.Translate(Vector3.back * Time.deltaTime * 10);
    }
}
