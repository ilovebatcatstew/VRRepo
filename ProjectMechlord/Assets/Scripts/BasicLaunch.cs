using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Functioning basic launch code - Feel free to touch as much as you like :)

// Make sure this thing is attached to some kind of player object with a camera (else the mouse click won't work).

public class BasicLaunch : MonoBehaviour
{
    public GameObject launchObject;
    public Transform missilePod1;
    public Transform missilePod2;
    
    public float cooldown = 10.0f;
    float timer;

    Mouse mouse;

    private void Awake()
    {
        mouse = Mouse.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (mouse.rightButton.isPressed && timer > cooldown)
        {
            FireDaGun();
            
        }
    }


    public void FireDaGun()
    {
        if (timer > cooldown)
        {
            Instantiate(launchObject, missilePod1.position, missilePod1.rotation);
            Instantiate(launchObject, missilePod2.position, missilePod2.rotation);
            timer = 0;
        }

    }


}
