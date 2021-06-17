using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// OLD AND BROKEN LAUNCHER CODE - DO NOT TOUCH
public class Launcher : MonoBehaviour
{
    public GameObject projectile;
    public PlayerInput playerInput;

    public int missileRows = 10;
    public int missileColumns = 5;

    public float cellWidth = 0.2f;
    public float cellHeight = 0.3f;

    public float cooldown = 10.0f;
    float timer = 0.0f;

    Mouse mouse;

   // GameObject[missileColumns][] missiles;


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
        
    }

    private void FixedUpdate()
    {
        //timer += Time.deltaTime;

        if (mouse.rightButton.isPressed )
        {
            // && timer >= cooldown
            // Fire a volley
            //projectile.transform.position = gameObject.transform.localPosition + (gameObject.transform.forward * gameObject.transform.localScale.z);
            //projectile.transform.rotation = gameObject.transform.rotation;
            //Instantiate(projectile);
            //timer = 0.0f;
            projectile.transform.SetParent( gameObject.transform);
            Instantiate(projectile);
           // FireProjectile();
        }
    }

    void FireProjectile()
    {
        float width = gameObject.transform.localScale.x;
        float height = gameObject.transform.localScale.y;

        float xOffset = width / 6;
        float yOffset = height / 11;

        // Somehow put the starting position in the bottom left corner
        //Vector3 startingOffset = Vector3.zero;
        //Vector3 podFront = gameObject.transform.position + (gameObject.transform.forward * gameObject.transform.localScale.z);
        //
        //startingOffset.x = gameObject.transform.localPosition.x - xOffset;
        //startingOffset.y = gameObject.transform.localPosition.y - yOffset;

        projectile.transform.position = Vector3.ProjectOnPlane(gameObject.transform.localPosition + (gameObject.transform.forward * gameObject.transform.localScale.z), gameObject.transform.forward);


        projectile.transform.rotation = gameObject.transform.rotation;
        //projectile.transform.position = startingOffset + podFront;

        // Set the projectime position to be the pod's

        Instantiate(projectile);

    }
}
