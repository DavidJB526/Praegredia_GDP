using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatEvent : MonoBehaviour {
    public static int enemyKilled=1;

    public delegate void EnemyEventHandler(IEnemy enemy);
    public static event EnemyEventHandler OnEnemyDeath;

   public static KillGoal killGoal;
    
    //public static void EnemyDied(IEnemy enemy)
    //{
    //   // killGoal = new KillGoal();

    //    Debug.Log("Registered Death");
    //    if (enemy != null)
    //    {
    //        Debug.Log("Got HERE BITTTCHHHH!!!");
    //        enemyKilled = 0;
    //        killGoal.EnemyDies();
            
    //        //return true;
    //    }
    //   //return false;
    //}
   

    public static void EnemyDied(IEnemy enemy)
    {
        if (OnEnemyDeath != null)
            OnEnemyDeath(enemy);
    }
}
