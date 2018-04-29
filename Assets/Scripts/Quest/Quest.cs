using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour {


    public List<Goal> Goals { get; set; } 
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int SkillPointReward { get; set; }
    public GameObject ItemReward { get; set; }
    public bool Completed { get; set; }

    

    public void CheckGoals()
    {
       if(Goals.All(g => g.Completed))
        {
            Completed = true;
            Debug.Log("All goals completed");
        }
       // Completed = Goals.All(g => g.Completed);
        
    }

    public void GiveReward()
    {
        if (ItemReward != null)
            ItemReward.SetActive(true);
        skillTree.skillPoints += SkillPointReward;
        
    }
}
