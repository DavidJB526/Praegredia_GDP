using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuItem : MonoBehaviour
{

    private InventoryMenu inventoryMenu;

    public InventoryObject InventoryObjectRepresented { get; set; }

    private List<GameObject> menuItems;
    private string defaultDescriptionText;

    public List<InventoryObject> PlayerInventory { get; private set; }

    void Start()
    {
        inventoryMenu = FindObjectOfType<InventoryMenu>();
    }

    public void OnValueChanged()
    {
       
       inventoryMenu.UpdateDescriptionAreaText(InventoryObjectRepresented.DescriptionText);
    }

}
