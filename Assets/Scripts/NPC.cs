using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public string name;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Interact();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            
            if(Input.GetButtonDown("Interact"))
            {
                Debug.Log("-");
                DialogueSystem.Instance.ContinueDialogue();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            DialogueSystem.Instance.DialogueAbruptEnd(); 
        }
    }

    public virtual void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
    }
}
