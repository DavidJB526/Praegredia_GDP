using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityGaining : MonoBehaviour
{
    //UI messages
    [SerializeField]
    private Text interactMessage, abiltiesGainedMessage;

    //The slider around the interact button
    [SerializeField]
    private Slider interactSliderCounter;

    //The creature object that the player is gaining the ability from
    private GameObject creature;
	// Use this for initialization

	void Start ()
    {
        //On start up, the UI messages should be empty and you shouldn't see anything
        interactMessage.text = string.Empty;
        abiltiesGainedMessage.text = string.Empty;
	}

    private void OnTriggerEnter(Collider other)
    {
        //Setting the creature object to that creature that enters the trigger
        if (other.tag == "Creature")
        {
            creature = other.gameObject;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Creature")
        {
            if (creature.GetComponent<Creature>().abilityReceived == false)
            {
                //When a creature comes in to the trigger, pop the interaction

                interactMessage.text = "Hold E";

                if (Input.GetButton("Interact") && other.tag == "Creature")
                {
                    //When the button is pressed, start the coroutine

                    StartCoroutine("GainingAbilities");
                }
                else if (Input.GetButtonUp("Interact"))
                {
                    //if the button is not pressed, restart the coroutine and reset the counter
                    StopCoroutine("GainingAbilities");
                    interactSliderCounter.value = 0;
                }
            }
            else
            {
                StopCoroutine("GainingAbilities");
                interactMessage.text = string.Empty;
                abiltiesGainedMessage.text = string.Empty;
                interactSliderCounter.value = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if the creature exits the trigger, restart the coroutine and the counter
        if(other.tag == "Creature")
        {
            interactMessage.text = string.Empty;
            StopCoroutine("GainingAbilities");
            interactSliderCounter.value = 0;
        }
    }

    private IEnumerator GainingAbilities()
    {
        //first set a bool to false to check when the loop is done
        bool finished = false;
        do
        {
            //Increase the slider value by one, wait a second, then continue to add
            interactSliderCounter.value++;
            yield return new WaitForSeconds(1);
            //When the value equals the max, change the bool to true and end the loop
            if (interactSliderCounter.value == interactSliderCounter.maxValue)
                finished = true;

        } while (!finished);
        
        //Display the abilities gained text
        abiltiesGainedMessage.text = "New Ability has been Acquired!";
        //Once the loop is finished, remove the interact message
        interactMessage.text = string.Empty;
        interactSliderCounter.value = 0;
        Debug.Log("Gained an ability");
        creature.GetComponent<Creature>().abilityReceived = true;
        yield return new WaitForSeconds(1);
        //Bool whether or not the creatures ability has been gained
        
        //Then remove that message
        abiltiesGainedMessage.text = string.Empty;
        

    }
}
