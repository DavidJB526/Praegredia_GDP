using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed;
    public float jumpHeight;
    public float sprintSpeed;
    public Transform playerBody;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject playerMenu;
    public float mouseSpeed;
    public float rotateSpeed;
    private bool canMove;

    // Use this for initialization
    void Start () {

        //Player spawns in
        transform.position = new Vector3(0, 2, 0);

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
            Move();
            Jump();
            Rotate();
            SwitchPerspective();
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
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
        //moves forward and back
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);

        //sprint
        if (Input.GetKey("left shift"))
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * sprintSpeed);
        }
    }

    //jump
    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
        }
    }

    //rotates the camera based on mouse input
    void Rotate()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(Vector3.down * mouseSpeed);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up * mouseSpeed);
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
            playerMenu.SetActive(!canMove);
        }

        //turns cursor & playerMenu off with escape
        if(Input.GetKeyDown("escape") && canMove == false)
        {
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            playerMenu.SetActive(!canMove);
        }
    }
}
