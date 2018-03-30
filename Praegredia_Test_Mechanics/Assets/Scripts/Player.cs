using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed;
    public float jumpHeight;
    public float sprintSpeed;
    public Transform playerBody;
    public GameObject playerCamera;
    public float mouseSpeed;
    public float rotateSpeed;

    // Use this for initialization
    void Start () {

        //Player spawns in
        transform.position = new Vector3(0, 2, 0);

        //Removes cursor
        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

        //turns cursor back on with escape
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Move();
        Jump();
        Rotate();

    }

    //player movement
    void Move()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
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
}
