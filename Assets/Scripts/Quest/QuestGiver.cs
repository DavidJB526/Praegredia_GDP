using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private string questType;

    private Quest Quest { get; set; }

    [SerializeField]
    Text questDescription;
    [SerializeField]
    Text questName;

    public override void Interact()
    {
        
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "" }, name);
        }
    }

    void AssignQuest()
    {
        Debug.Log("Quest Active");
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        questDescription.text = Quest.Description;
        questName.text = Quest.QuestName;
    }
	
    void CheckQuest()
    {
        if(Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you." }, name );
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "" }, name);
        }
    }

}
