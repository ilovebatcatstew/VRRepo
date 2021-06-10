using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{

    public CharacterController controllerRef;

    float xRotation;

    public PlayerInput playerInput;

    Camera cam;

    float mouseX;
    float mouseY;

    public void MouseLook(InputAction.CallbackContext context)
    {
       // Debug.Log("Mouse moved");
        Vector2 delta = context.ReadValue<Vector2>();
      //  Debug.Log("Mouse X: " + delta.x + "Mouse Y: " + delta.y);

        mouseX = delta.x;
        mouseY = delta.y;

    }

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 90f;
        //float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 90f;

        mouseX *= Time.deltaTime * 90f;
        mouseY *= Time.deltaTime * 90f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);

        controllerRef.transform.Rotate(Vector3.up * mouseX);

        //  cam.transform.rotation = controllerRef.transform.rotation;
       // cam.transform.position = controllerRef.transform.position;
    }

    void FixedUpdate()
    {
        
    }
}
