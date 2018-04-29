using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoQuest : Quest
{


    // Use this for initialization
    void Start()
    {
        QuestName = "Retrieve the Tribesmen's Stolen Item";
        Description = "Go to the nearby cave where a colonist has holded up. Retrieve the stolen item from him.";
        ItemReward = GameObject.Find("QuestReward");
        SkillPointReward = 2;

        Goals = new List<Goal>
        {
            new KillGoal(this, 0, "Eliminate the colonist in the cave.", false, 0, 1)


        };

        Goals.ForEach(g => g.Init());
	}
	
	
}
