using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCam : MonoBehaviour {

    public float yaxis = 0.1f;
    public float xaxis = 0.1f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {

        tempPos = posOffset;
        
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * yaxis;
        tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * xaxis;

        transform.position = tempPos;
    }
}
