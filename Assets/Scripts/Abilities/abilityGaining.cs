using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityGaining : MonoBehaviour
{
    //UI messages
    [SerializeField]
    private Text interactMessage;
    [SerializeField]
    private GameObject abilitiesImage;

    //The slider around the interact button
    [SerializeField]
    private Slider interactSliderCounter;
    [SerializeField]
    private Collider abilitiesCollider;


   
    private bool finished = false;
        
	// Use this for initialization

	void Start ()
    {
        //On start up, the UI messages should be empty and you shouldn't see anything
        interactMessage.text = string.Empty;
        
	}


    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            
                //When a creature comes in to the trigger, pop the interaction

                interactMessage.text = "Hold E";

                if (Input.GetButton("Interact") && player.tag == "Player")
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
    }

    private void OnTriggerExit(Collider player)
    {
        //if the creature exits the trigger, restart the coroutine and the counter
        if(player.tag == "Player")
        {
            interactMessage.text = string.Empty;
            StopCoroutine("GainingAbilities");
            interactSliderCounter.value = 0;
        }
    }

    private IEnumerator GainingAbilities()
    {
        //first set a bool to false to check when the loop is done
        
        do{
            //Increase the slider value by one, wait a second, then continue to add
            interactSliderCounter.value++;
            yield return new WaitForSeconds(1);
            //When the value equals the max, change the bool to true and end the loop
            if (interactSliderCounter.value == interactSliderCounter.maxValue)
                finished = true;

        } while (!finished);


        abilitiesImage.SetActive(true);
        if(abilitiesImage.name == "AbilityActive")
        {
            GameObject.FindWithTag("Player").GetComponent<fireAbility>().enabled = true;
        }
        else if(abilitiesImage.name == "AbilityPassive")
        {
            GameObject.FindWithTag("Player").GetComponent<sprintAbility>().enabled = true;
        }
        //Once the loop is finished, remove the interact message
        interactMessage.text = string.Empty;
        interactSliderCounter.value = 0;

        abilitiesCollider.enabled = false;
        
        

    }
}
