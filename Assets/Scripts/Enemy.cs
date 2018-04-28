using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    Transform target;

    NavMeshAgent agent;

    [SerializeField]
    float lookRadius = 5;

    [SerializeField]
    float health = 50f;

    public int ID { get; set; }


    private void Start()
    {
        ID = 0;
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            GetComponent<AIpatrol>().enabled = false;
            agent.SetDestination(target.position);
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(health);
        health -= amount;
        if(health <= 0)
        {
            
            Die();
        }
    }

    public void Die()
    {
        CombatEvent.EnemyDied(this);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
