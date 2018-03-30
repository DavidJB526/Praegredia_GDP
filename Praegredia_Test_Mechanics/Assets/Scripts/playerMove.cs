using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public float sprintSpeed;

    // Use this for initialization
    void Start()
    {
        
        //Player spawns in
        this.gameObject.transform.position = new Vector3(0, 2, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        this.gameObject.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
        this.gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);

        if (Input.GetKeyDown("space"))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
        }

        if (Input.GetKey("left shift"))
        {
            this.gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * sprintSpeed);
        }
    }
}
