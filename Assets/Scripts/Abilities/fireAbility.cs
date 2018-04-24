using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAbility : MonoBehaviour {

    [SerializeField]
    Transform fireTransform;
    [SerializeField]
    float force;
    [SerializeField]
    float lifeTime = 2f;
    [SerializeField]
    Rigidbody fireball;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        Rigidbody fireInstance = Instantiate(fireball, fireTransform.position, fireTransform.rotation) as Rigidbody;
        fireInstance.velocity = force * fireTransform.forward;
        Destroy(fireInstance, lifeTime);
    }
}
