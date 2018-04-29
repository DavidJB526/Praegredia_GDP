using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    [SerializeField]
    private float attackDamage;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit: " + collider.name);

        if(collider.tag == "Enemy")
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
