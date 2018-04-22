using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{


    [SerializeField]
    float health = 50f;

    public int ID { get; set; }


    private void Start()
    {
        ID = 0;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        CombatEvent.EnemyDied(this);
        Destroy(gameObject);
    }
}
