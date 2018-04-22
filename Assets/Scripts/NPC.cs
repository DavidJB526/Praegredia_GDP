using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour {
    public string[] dialogue;
    public string name;

    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Interact();
            if(Input.GetButtonDown("Interact"))
            {
                DialogueSystem.Instance.ContinueDialogue();
            }
        }
    }

    public void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
    }
}
