using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{

    public float playerSpeed = 1.0f;

    public PlayerInput playerInput; 

    CharacterController controller;

    Vector3 playerVelocity;

    Vector2 playerMovement;

    bool keyW;
    bool keyA;
    bool keyS;
    bool keyD;

    public void WKeyPressed(InputAction.CallbackContext context)
    {
      //  Debug.Log("W key pressed");
        Vector2 inputMovement = context.ReadValue<Vector2>();
        //Debug.Log("X value: " + inputMovement.x + " Y Value: " + inputMovement.y);

        playerMovement = new Vector2(inputMovement.x, inputMovement.y);
    }

    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        //Input.anyKey.

        // Input.

        //if(UnityEngine.Keyboard)
        //{
        //    keyW = true;
        //}
        //else
        //{
        //    keyW = false;
        //}

    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(0,0,0);

        if(playerMovement.y > 0)
        {
            movement += controller.transform.forward;
        }
        else if(playerMovement.y < 0)
        {
            movement -= controller.transform.forward;
        }

        if(playerMovement.x < 0)
        {
            movement -= controller.transform.right;
        }
        else if(playerMovement.x > 0)
        {
            movement += controller.transform.right;
        }

        movement *= playerSpeed * Time.deltaTime;

        controller.Move(movement);

    }
        
}
