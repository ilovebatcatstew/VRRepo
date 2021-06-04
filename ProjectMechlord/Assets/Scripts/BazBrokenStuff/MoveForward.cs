using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public bool isMoveForward;
    public bool isMoveBackward;
    public bool isRotateLeft;
    public bool isRotateRight;

    PlayerMovement player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (isRotateLeft)
            {
                RotateLeft();
            }
            if (isRotateRight)
            {
                RotateRight();
            }


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (isMoveForward)
            {
                MoveFoward();
            }
            if (isMoveBackward)
            {
                MoveBackward();
            }
        }
        
    }



    void MoveFoward()
    {
        player.Move();
    }

    void MoveBackward()
    {

    }

    void RotateLeft()
    {
        player.RotL();
    }

    void RotateRight()
    {
        player.RotR();
    }


}
