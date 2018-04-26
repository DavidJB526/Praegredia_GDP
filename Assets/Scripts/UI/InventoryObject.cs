using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{


    [SerializeField]
    private string nameText;

    [SerializeField]
    private string descriptionText;

    private MeshRenderer meshRenderer;
    private InventoryMenu inventoryMenu;
    private Collider collider;

    private bool itemTaken = false;

    public string NameText
    {
        get
        {
            return nameText;
        }
    }

    public string DescriptionText { get { return descriptionText; } }

    private void Start()
    {
        inventoryMenu = FindObjectOfType<InventoryMenu>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(itemTaken == false)
        {
           // if(Input.GetKeyDown("e"))
            if (Input.GetButtonDown("ItemPickup"))
             {
                 inventoryMenu.PlayerInventory.Add(this);

                 meshRenderer.enabled = false;
                 collider.enabled = false;
                itemTaken = true;
             }

        }



    }

    




}
