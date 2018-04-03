using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //Player controls stats
    [SerializeField]
    private float playerSpeed, jumpHeight, sprintSpeed, mouseSpeed, rotateSpeed;

    //The playerBody
    [SerializeField]
    private GameObject playerBody;
    //The player's perspectives
    [SerializeField]
    public GameObject firstPersonCamera, thirdPersonCamera;
    //Player's inventory UI
    [SerializeField]
    private GameObject playerMenu;

    //Boolean to determine whether the player can move or not
    private bool canMove;

    // Use this for initialization
    void Start () {

        //Player spawns in
        playerBody.transform.position = new Vector3(0, 2, 0);

        //Removes cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Allows player to move
        canMove = true;

        //Turns playerMenu off
        
        playerMenu.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {
            playerBody.GetComponent<Rigidbody>().isKinematic = false;
            Move();
            Jump();
            Rotate();
            SwitchPerspective();
        }
        else if(!canMove)
        {
            playerBody.GetComponent<Rigidbody>().isKinematic = true;
        }
        //Move();
        //Jump();
        //Rotate();
        //SwitchPerspective();
        ToggleMenu();
    }

    //player movement
    void Move()
    {
        //moves left and right
        playerBody.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
        //moves forward and back
        playerBody.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);

        //sprint
        if (Input.GetKey("left shift"))
        {
            playerBody.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * sprintSpeed);
        }
    }

    //jump
    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            playerBody.transform.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
        }
    }

    //rotates the camera based on mouse input
    void Rotate()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            playerBody.transform.Rotate(Vector3.down * mouseSpeed);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            playerBody.transform.Rotate(Vector3.up * mouseSpeed);
        }
    }

    //switches between first and third person
    void SwitchPerspective()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (firstPersonCamera.activeSelf == true)
            {
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
            }
            else
            {
                thirdPersonCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
            }
        }
    }

    //turns cursor and menu on/off
    void ToggleMenu()
    {
        //turns cursor & playerMenu on with escape
        if (Input.GetKeyDown("escape") && canMove == true)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            playerMenu.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && canMove == false)
        {
            //turns cursor & playerMenu off with escape
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerMenu.SetActive(false);
        }
        

    }
}
