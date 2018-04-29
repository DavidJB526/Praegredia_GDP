using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }
   
    public GameObject dialoguePanel;
    public string npcName;

    public List<string> dialogueLines = new List<string>();

    Text dialogueText, nameText;
    int dialogueIndex;

    private void Awake()
    {
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NPC Name").Find("Text").GetComponent<Text>();
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        CreateDialogue();

        
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);

    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count -1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
            Debug.Log(dialogueIndex);
        }
        else
        {
            dialoguePanel.SetActive(false);
            dialogueIndex = 0;
        }
    }

    public void DialogueAbruptEnd()
    {
        dialogueIndex = 0;
        dialoguePanel.SetActive(false);
        
    }
}
