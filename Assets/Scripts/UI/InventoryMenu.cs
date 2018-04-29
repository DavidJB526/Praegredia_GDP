using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuPanel;


    [SerializeField]
    private GameObject menuItemPrefab;

    [SerializeField]
    Transform inventoryItemListPanel;

    [SerializeField]
    Text descriptionAreaText;

    private List<GameObject> menuItems;
    private string defaultDescriptionText;

    public List<InventoryObject> PlayerInventory { get; private set; }

    bool IsVisible
    {
        get { return inventoryMenuPanel.activeSelf; }
    }

    public void UpdateDescriptionAreaText(string descriptionText)
    {
        descriptionAreaText.text = descriptionText;
    }

    private void Awake()
    {
        defaultDescriptionText = descriptionAreaText.text;
        PlayerInventory = new List<InventoryObject>();
        menuItems = new List<GameObject>();
       
        
    }

   

    private  void ShowMenu()
    {
        UpdateDescriptionAreaText(defaultDescriptionText);
        GenerateMenuItems();
        
    }
    
    private void HideMenu()
    {
        
        DestroyInventoryMenuItems();
    }

    private void DestroyInventoryMenuItems()
    {
        foreach (var item in menuItems)
        {
            Destroy(item);
        }
    }
    private void GenerateMenuItems()
    {
        foreach (InventoryObject item in PlayerInventory)
        {
            GameObject newMenuItem = Instantiate(menuItemPrefab, inventoryItemListPanel) as GameObject;

            // Set the toggle group so only one item at a time can be selected
            newMenuItem.GetComponent<Toggle>().group = inventoryItemListPanel.GetComponent<ToggleGroup>();

            // Set the toggle label name text (it's on a child gameobject of the toggle)
            newMenuItem.GetComponentInChildren<Text>().text = item.NameText;

            // Tell the menu item what object it is representing
            newMenuItem.GetComponent<InventoryMenuItem>().InventoryObjectRepresented = item;

            menuItems.Add(newMenuItem);

            Debug.Log("Number check");
            
            
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown("escape") )
        {
            if (!IsVisible)
            {
                HideMenu();
                
            }
            else
            {

                ShowMenu();
                
               
            }
           
        }

       

    }
    private void Update()
    {
        HandleInput();
       
    }


}
