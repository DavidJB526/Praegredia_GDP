using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    [SerializeField]
    float maxDamage = 50f;
    [SerializeField]
    public float lifeTime = 2f;
    [SerializeField]
    float radius = 3f;


    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit: " + collider.name);

        if (collider.tag == "Enemy")
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(maxDamage);
            }
        }
        
        if(collider != null)
        {
            Destroy(gameObject);
        }
    }

    //float CalculateDamage(Vector3 targetPosition)
    //{
    //    Vector3 explosionToTarget = targetPosition - transform.position;

    //    float explosionDistance = explosionToTarget.magnitude;

    //    float relativeDistance = (radius - explosionDistance) / radius;

    //    float damage = relativeDistance * maxDamage;

    //    damage = Mathf.Max(0f, damage);

    //    return damage;
    //}
}
