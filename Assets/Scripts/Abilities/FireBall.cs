using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    [SerializeField]
    LayerMask attackable;
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

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, attackable);

        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigibody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigibody)
                continue;
            Enemy targetHealth = targetRigibody.GetComponent<Enemy>();
            if (!targetHealth)
                continue;
            float damage = CalculateDamage(targetRigibody.position);

            targetHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (radius - explosionDistance) / radius;

        float damage = relativeDistance * maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
