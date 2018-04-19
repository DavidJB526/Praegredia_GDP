using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

    [SerializeField]
    float lifeTime = 2;
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, lifeTime);
	}
}
