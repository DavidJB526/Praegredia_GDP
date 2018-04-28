using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIFunctionality : MonoBehaviour {

    //Fields for the UI screens aka panels
    [SerializeField]
    private GameObject inventoryPanel, characterPanel, skillsPanel, mapPanel, questPanel, optionsPanel;
    //Fields for the UI buttons
    private Button inventoryButton, characterButton, skillButton, mapButton, questButton, optionsButton;

	// Use this for initialization
	void Start ()
    {
        inventoryButton = GameObject.Find("Inventory").GetComponent<Button>();
        characterButton = GameObject.Find("Character").GetComponent<Button>();
        skillButton = GameObject.Find("Skills").GetComponent<Button>();
        mapButton = GameObject.Find("Map").GetComponent<Button>();
        questButton = GameObject.Find("Quests").GetComponent<Button>();
        optionsButton = GameObject.Find("Options").GetComponent<Button>();
    }
	

    //When the Inventory button is pressed
    public void InventoryScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(true);
        characterPanel.SetActive(false);
        skillsPanel.SetActive(false);
        mapPanel.SetActive(false);
        questPanel.SetActive(false);
        optionsPanel.SetActive(false);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = false;
        characterButton.interactable = true;
        skillButton.interactable = true;
        mapButton.interactable = true;
        questButton.interactable = true;
        optionsButton.interactable = true;
    }

    public void CharacterScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(false);
        characterPanel.SetActive(true);
        skillsPanel.SetActive(false);
        mapPanel.SetActive(false);
        questPanel.SetActive(false);
        optionsPanel.SetActive(false);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = true;
        characterButton.interactable = false;
        skillButton.interactable = true;
        mapButton.interactable = true;
        questButton.interactable = true;
        optionsButton.interactable = true;
    }

    //When the skills/abilities button is pressed
    public void SkillsScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(false);
        characterPanel.SetActive(false);
        skillsPanel.SetActive(true);
        mapPanel.SetActive(false);
        questPanel.SetActive(false);
        optionsPanel.SetActive(false);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = true;
        characterButton.interactable = true;
        skillButton.interactable = false;
        mapButton.interactable = true;
        questButton.interactable = true;
        optionsButton.interactable = true;
    }
    //When the map button is pressed
    public void MapScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(false);
        characterPanel.SetActive(false);
        skillsPanel.SetActive(false);
        mapPanel.SetActive(true);
        questPanel.SetActive(false);
        optionsPanel.SetActive(false);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = true;
        characterButton.interactable = true;
        skillButton.interactable = true;
        mapButton.interactable = false;
        questButton.interactable = true;
        optionsButton.interactable = true;
    }
    //When the quest button is pressed
    public void QuestScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(false);
        characterPanel.SetActive(false);
        skillsPanel.SetActive(false);
        mapPanel.SetActive(false);
        questPanel.SetActive(true);
        optionsPanel.SetActive(false);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = true;
        characterButton.interactable = true;
        skillButton.interactable = true;
        mapButton.interactable = true;
        questButton.interactable = false;
        optionsButton.interactable = true;
    }
    //When the options button is pressed
    public void OptionsScreen()
    {
        //Setting the correct panel to appear
        inventoryPanel.SetActive(false);
        characterPanel.SetActive(false);
        skillsPanel.SetActive(false);
        mapPanel.SetActive(false);
        questPanel.SetActive(false);
        optionsPanel.SetActive(true);
        //Making sure that buttons are interactable, but the current screens one is not
        inventoryButton.interactable = true;
        characterButton.interactable = true;
        skillButton.interactable = true;
        mapButton.interactable = true;
        questButton.interactable = true;
        optionsButton.interactable = false;
    }



}
