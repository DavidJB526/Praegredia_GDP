using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //Player controls stats
    [SerializeField]
    private float jumpHeight, sprintSpeed, mouseSpeed, rotateSpeed;

    public static float playerSpeed = 0.4f;

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

    //Boolean to determine whether the player can move or not
    private bool canMove;

    //Boolean to determine whether the player can move or not
    private bool canAttack;

    //Boolen to determine whether the player is on the ground
    private bool isGrounded;

    public float stamina = 100f;

    public float health = 100f;

    public float staminaDecay = 1.2f;

    private bool canSprint = true;

    //Whether the character is Active or Inactive
    private bool isActive;

    private Animator anim;
    

    // Use this for initialization
    void Start () {

        //Player spawns in
        //playerBody.transform.position = new Vector3(0, 2, 0);

        //Reset playerSpeed
        playerSpeed = 0.4f;

        //Removes and locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Allows player to move
        Activate();

        //Turns playerMenu off
        anim = GetComponent<Animator>();
        
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
            MeleeAttack();

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
        float walking = Input.GetAxis("Vertical");
        playerBody.transform.Translate(Vector3.forward * walking * playerSpeed);
        anim.SetFloat("walking", walking);
        //sprint
        if (Input.GetKey("left shift") && canSprint)
        {
            playerBody.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * sprintSpeed);
            StaminaDecay();
        }
        else if (stamina < 100)
        {
            StaminaRecover();
        }
    }


    //jump
    void Jump()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            playerBody.transform.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
            isGrounded = false;
        }
    }

    //when the Player punches
    void MeleeAttack()
    {
        
        if (canAttack && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackAnimation());
            anim.SetBool("attack", true);
            canAttack = false;
            //GetComponent<Animator>().SetTrigger("playerMelee");
            Debug.Log("Punch");
            EndAttack();
        }
    }

    IEnumerator AttackAnimation()
    {

        
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("attack", false);
    }

    void EndAttack()
    {
        canAttack = true;
       
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
        if (Input.GetKeyDown("escape") && canMove == true && isActive == true)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMenu.SetActive(true);
            inventoryButton.interactable = false;
        }
        else if (Input.GetKeyDown("escape") && canMove == false && isActive == true)
        {
            //turns cursor & playerMenu off with escape
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerMenu.SetActive(false);
        }
        //if character is not active the menu will not show up
        else if (Input.GetKeyDown("escape") && isActive == false)
        {
            return;
        }

    }

    //Activates or deactivates camera and controls from the player. Used by PlayerSwap
    void Activate()
    {
        isActive = true;
        canAttack = true;
        canMove = true;
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
    }

    void Deactivate()
    {
        isActive = false;
        canMove = false;
        canAttack = false;
        thirdPersonCamera.SetActive(false);
        firstPersonCamera.SetActive(false);
    }

    //Checks for collision, built in Unity tool
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void StaminaDecay()
    {
        stamina -=  Time.deltaTime * staminaDecay;
        if(stamina <= 0)
        {
            stamina = 0;
            canSprint = false;
        }
    }

    private void StaminaRecover()
    {
        stamina += Time.deltaTime * (staminaDecay * 1.5f);
        if(stamina > 20)
        {
            canSprint = true;
        }
        if(stamina > 100)
        {
            stamina = 100;
        }
    }

}
