using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour {

    //characters switching between
    [SerializeField]
    private GameObject character1, character2;

    //third person cameras for each player
    [SerializeField]
    private GameObject camera1, camera2;

    //private void Awake()
    //{
    //    character2.gameObject.SendMessage("Deactivate");
    //    camera2.SetActive(false);
    //}


    //2 inputs for swapping characters, "1" swaps to player 1, "2" swaps to player 2. Sends to "Activate()" in player controller
    private void Update()
    {
        if (Input.GetButtonDown("CharacterSwapto2"))
        {
            character1.gameObject.SendMessage("Deactivate");
            character2.gameObject.SendMessage("Activate");

            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        if (Input.GetButtonDown("CharacterSwapto1"))
        {
            character2.gameObject.SendMessage("Deactivate");
            character1.gameObject.SendMessage("Activate");

            camera2.SetActive(false);
            camera1.SetActive(true);
        }

    }





    //   var Character1 : Transform = null;
    //var Character2 : Transform = null;


    //function Update()
    //   {

    //       if (Input.GetKey(KeyCode.N))
    //       {

    //           Character1.gameObject.SendMessage("Activate");
    //           Character2.gameObject.SendMessage("Deactivate");
    //       }

    //       if (Input.GetKey(KeyCode.B))
    //       {

    //           Character2.gameObject.SendMessage("Activate");
    //           Character1.gameObject.SendMessage("Deactivate");
    //       }

    //   }
}
