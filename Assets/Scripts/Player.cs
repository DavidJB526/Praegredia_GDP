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
    [SerializeField]
    private Button inventoryButton;

    // stamina number
    public float stamina = 100;

    // stamina decay rate
    public float staminaDecay = 5.0f;

    // health number
    public float health = 100;

    //Boolean to determine whether the player can move or not
    private bool canMove;

    //Boolen to determine whether the player is on the ground
    private bool isGrounded;

    // Use this for initialization
    void Start () {

        //Player spawns in
        //playerBody.transform.position = new Vector3(0, 2, 0);

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
        if (Input.GetButton("Sprint") && stamina > 0)
        {
            playerBody.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * sprintSpeed);
            StaminaDecay();
        }
        else if(stamina < 100)
        {
            StaminaRegin();
        }
    }

    //jump
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerBody.transform.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
            isGrounded = false;
        }
    }

    //rotates the camera based on mouse input
    void Rotate()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            playerBody.transform.Rotate(Vector3.down * rotateSpeed);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            playerBody.transform.Rotate(Vector3.up * rotateSpeed);
        }
        
        /*
        thirdPersonCamera.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * 
            Time.deltaTime * mouseSpeed);
        */
        
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
            Cursor.visible = true;
            playerMenu.SetActive(true);
            inventoryButton.interactable = false;
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

    //Checks for collision, built in Unity tool
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // decay stamina
    private void StaminaDecay()
    {
        stamina -= Time.deltaTime * staminaDecay;
        if(stamina < 0)
        {
            stamina = 0;
        }
    }

    // increase stamina
    private void StaminaRegin()
    {
        stamina += Time.deltaTime * (staminaDecay * 1.5f);
        if(stamina > 100)
        {
            stamina = 100;
        }
    }
}
