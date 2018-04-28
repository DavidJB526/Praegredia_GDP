using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectiles : MonoBehaviour {

    [SerializeField]
    float Dartdamge = 10;
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

    public int dartAmount = 10;

    [SerializeField]
    Text dartAmountText;

    Rigidbody dartInstance;
	// Update is called once per frame
	void Update ()
    {
        dartAmountText.text = "Darts: " + dartAmount;
        if (Input.GetButtonDown("Fire1") && dartAmount > 0)
        {
            ShootDart();
        }
	}

    void ShootDart()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(dartTransform.position, dartTransform.up, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(Dartdamge);
                
            }

            
        }
        dartInstance = Instantiate(dart, dartTransform.position, dartTransform.rotation) as Rigidbody;
        dartInstance.velocity = launchForce * dartTransform.up;
        dartAmount--;
        Destroy(dartInstance, lifeTime);

    }
}
