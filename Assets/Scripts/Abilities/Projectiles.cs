using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    [SerializeField]
    float Dartdamge;
    [SerializeField]
    float range = 10;

    [SerializeField]
    Transform dartTransform;

    [SerializeField]
    Rigidbody dart;

    [SerializeField]
    float launchForce = 10;

    [SerializeField]
    float lifeTime = 3;

    Rigidbody dartInstance;
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            ShootDart();
        }
	}

    void ShootDart()
    {
        RaycastHit hit;
        if(Physics.Raycast(dartTransform.position, dartTransform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(Dartdamge);
                
            }

            
        }
        dartInstance = Instantiate(dart, dartTransform.position, dartTransform.rotation) as Rigidbody;
        dartInstance.velocity = launchForce * dartTransform.forward;
        Destroy(dartInstance, lifeTime);

    }
}
