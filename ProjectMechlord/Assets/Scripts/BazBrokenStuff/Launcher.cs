using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    public GameObject projectile;
    public PlayerInput playerInput;

    Mouse mouse;


    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            
        }
    }

    void Awake()
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
        if(mouse.leftButton.isPressed)
        {
            projectile.transform.position = gameObject.transform.position;
            projectile.transform.rotation = gameObject.transform.rotation;
            Instantiate(projectile);
        }
    }
}
