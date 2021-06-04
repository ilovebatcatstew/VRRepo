using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public GameObject movehere;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        transform.position = movehere.transform.position;
    }

    void Update()
    {
        /*
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        */
        
    }
}
