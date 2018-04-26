using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceblock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //if (collision.gameObject.name == "player" )

        if(other.tag == "Fireball")
        {
            breakIce();
            
        }
    }

    private void breakIce()
    {
        Destroy(gameObject);
    }
}
