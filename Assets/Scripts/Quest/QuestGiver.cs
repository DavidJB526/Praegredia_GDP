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

    [SerializeField]
    GameObject item;

    public override void Interact()
    {
        
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
            questDescription.text = "Find a way through the ice covered cave and take care of the stray colonist.";
            questName.text = "Protecting the Tribe";
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Nice to see you again, brother. Don't forget that the amulet is a key to the hidden passage in the cave." }, name);
        }
    }

    void AssignQuest()
    {
        Debug.Log("Quest Active");
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        
    }
	
    void CheckQuest()
    {
        Quest.CheckGoals();

        if(Quest.Completed == true)
        {
            Debug.Log("Quest completed");
            //Quest.GiveReward();
            item.SetActive(true);
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you for your help, brother. Here's an amulet as a reward. Return to gave and it should open the hidden passage there." }, name );
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Please handle the colonist. The cave is to the north, follow the path until you spot a muddy trail lead into the forest." }, name);
        }
    }

}
