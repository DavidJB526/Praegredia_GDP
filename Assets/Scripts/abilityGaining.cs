using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityGaining : MonoBehaviour {

    [SerializeField]
    private Text interactMessage, abiltiesGainedMessage;

    [SerializeField]
    private Slider interactSliderCounter;

    private GameObject creature;
	// Use this for initialization
	void Start ()
    {
        interactMessage.text = string.Empty;
        abiltiesGainedMessage.text = string.Empty;
	}


    private void OnTriggerStay(Collider other)
    {

        interactMessage.text = "Hold E";
        if(Input.GetButton("Interact") && other.tag == "Creature")
        {
            StartCoroutine("GainingAbilities");
        }
        else
        {
            StopCoroutine("GainingAbilities");
            interactSliderCounter.value = 0;
        }

    }

    private IEnumerator GainingAbilities()
    {
        bool finished = false;
        do
        {
            interactSliderCounter.value++;
            yield return new WaitForSeconds(1);

            if (interactSliderCounter.value == interactSliderCounter.maxValue)
                finished = true;

        } while (!finished);

        interactMessage.text = string.Empty;
        abiltiesGainedMessage.text = "New Ability has been Acquired!";
        yield return new WaitForSeconds(5);
        abiltiesGainedMessage.text = string.Empty;

    }
}
