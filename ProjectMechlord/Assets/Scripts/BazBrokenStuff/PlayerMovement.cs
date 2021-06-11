using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController playerController;

    float currentSpeed;
    public float playerSpeed = 9f;
    public float crouchSpeed = 4f;
    public float sprintSpeed = 1.5f;
    public float jumpHeight;
    public float grav = -10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 vel;

    bool isGrounded;
    bool isCrouching;

    public Camera playerCamera;

    //Changeables
    public bool canSprint;
    public bool canCrouch;
    public bool canZoom;


    void Start()
    {
        currentSpeed = playerSpeed;
        isCrouching = false;
    }


    void Update()
    {

        //Movement Code
        {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && vel.y < 0)
        {
            vel.y = -2f;
        }

            //float xMovement = Input.GetAxis("Horizontal");
            //float zMovement = Input.GetAxis("Vertical");
            //
            //Vector3 move = transform.forward * zMovement;
            //
            //playerController.Move(move * currentSpeed * Time.deltaTime);
            //
            //vel.y += grav * Time.deltaTime;
            //
            //playerController.Move(vel * Time.deltaTime);
        }


        /* TO BE CHANGED
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Rotate(0, -25f, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Rotate(0, 25f, 0);
        }
        */
    }


    public void Move()
    {
        playerController.Move(transform.forward * currentSpeed * Time.deltaTime);
    }

    public void RotL()
    {
        gameObject.transform.Rotate(0, -25f, 0);
    }

    public void RotR()
    {
        gameObject.transform.Rotate(0, 25f, 0);
    }


}
