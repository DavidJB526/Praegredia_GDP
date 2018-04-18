using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit: " + collider.name);

        if(collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}
