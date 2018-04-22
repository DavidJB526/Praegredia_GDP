using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillTree : MonoBehaviour {

    public static float fireballLvl = 0;
    public static float passiveLvl = 0;
    public static float genericAbilityLvl = 0;

    public Button FireBallButton;
    public Button PassiveButton;
    public Button GenericAbilityButton;


    public static int skillPoints = 4;
    public static int skillPointsSpent = 0;

    public Text AbilityDescription;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //I commented out the GetComponent code to test the interactable code out.

		if (skillPoints == 0)
        {
            //FireBallButton.GetComponent<Button>().enabled = false;
            FireBallButton.interactable = false;

        }
        else
        {
            //FireBallButton.GetComponent<Button>().enabled = true;
            FireBallButton.interactable = true;
        }

        if (skillPoints == 0)
        {
            //PassiveButton.GetComponent<Button>().enabled = false;
            PassiveButton.interactable = false;

        }
        else
        {
            //PassiveButton.GetComponent<Button>().enabled = true;
            PassiveButton.interactable = true;
        }

        if ((skillPoints <= 1) || (skillPointsSpent <= 2))
        {
            //GenericAbilityButton.GetComponent<Button>().enabled = false;
            GenericAbilityButton.interactable = false;
        }

        if ((skillPoints >= 2) && (skillPointsSpent >= 2))
        {
            //GenericAbilityButton.GetComponent<Button>().enabled = true;
            GenericAbilityButton.interactable = true;
        }


    }

    public void FireballLevelUp()
    {
        fireballLvl += 1f;

        skillPoints -= 1;
        skillPointsSpent += 1;

        Debug.Log (fireballLvl);
    }
    public void Passive()
    {
        passiveLvl += 1f;

        skillPoints -= 1;
        skillPointsSpent += 1;

        Debug.Log(passiveLvl);
    }
    public void GenericAbility()
    {
        genericAbilityLvl += 1f;

        skillPoints -= 2;
        skillPointsSpent += 2;

        Debug.Log(genericAbilityLvl);
    }
    public void DescriptionPopUp ()
    {
        AbilityDescription.GetComponent<Text>().text = "FireBall";
    }
}
