using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartPickUp : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Projectiles>().dartAmount += 10;
            Destroy(gameObject);
        }
    }
}
