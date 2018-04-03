using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour {

    public Transform playerBody;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public float mouseSpeed;
    public float rotateSpeed;
    
    // Use this for initialization
    void Start () {
        
        //Removes cursor
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(Vector3.down * mouseSpeed);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up * mouseSpeed);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

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
}
