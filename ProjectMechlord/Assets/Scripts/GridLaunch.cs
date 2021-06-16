using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// WORK IN PROGRESS "COOL" LAUNCH - DO NOT TOUCH

public class GridLaunch : MonoBehaviour
{
    public GameObject launchObject;
    public Transform objectSpawnPosition;

    float width;  // Don't touch these, they're container variables
    float height; // Don't touch these, they're container variables
    float length; // Don't touch these, they're container variables

    float launchObjectWidth;   // Don't touch these, they're container variables
    float launchObjectHeight;  // Don't touch these, they're container variables

    public float launchInterval = 0.05f;

    public int rows = 10;
    public int columns = 6;

    public float cooldown = 10.0f;
    float timer = 0.0f;

    Mouse mouse;

    private void Awake()
    {
        mouse = Mouse.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        width = gameObject.transform.localScale.x;
        height = gameObject.transform.localScale.y;
        length = gameObject.transform.localScale.z;

        launchObjectWidth = launchObject.transform.localScale.x;
        launchObjectHeight = launchObject.transform.localScale.y;

        objectSpawnPosition = gameObject.transform;

        StartCoroutine(DebugLaunchVolley());

        //StartCoroutine(LaunchVolley());
        //Instantiate(launchObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //DebugLaunchVolley();
        //timer += Time.deltaTime;
        //if (mouse.rightButton.isPressed && timer > cooldown)
        //{
        //    StartCoroutine(LaunchVolley());
        //    timer = 0;
        //}
    }

    IEnumerator DebugLaunchVolley()
    {
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;


        float xOffset = width / columns;
        float yOffset = height / rows;

        float smallerWidth = width - 2 * xOffset;
        float smallerHeight = height - 2 * yOffset;

        float xStartPos = smallerWidth * 0.5f;
        float yStartPos = smallerHeight * 0.5f;

        float columnOffset = smallerWidth / (columns - 1);
        float rowOffset = smallerHeight / (rows - 1);

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Debug.DrawLine(transform.position + right * (-xStartPos + (x * columnOffset)) + up *(yStartPos - (y * rowOffset)), transform.position + right * (-xStartPos + (x * columnOffset)) + up * (yStartPos - (y * rowOffset)) + forward, Color.white);
                Instantiate(launchObject, transform.position + right * (-xStartPos + (x * columnOffset)) + up * (yStartPos - (y * rowOffset)), gameObject.transform.rotation);
                yield return new WaitForSeconds(launchInterval);
            }
        }


    }

    IEnumerator LaunchVolley()
    {
        // Start point should be on the 'left.

        Vector3 xStart = -transform.right * width * 0.5f; // This starts it off at the left edge of the object this is attached to.
        Vector3 xEnd = transform.right * width * 0.5f; // This is the end point of where the projectiles should spawn

        Vector3 yStart = transform.up * height * 0.5f;
        //Vector3 yStart = 

        Vector3 zStart = transform.forward * length * 0.5f;

        //xStart.x += launchObject.transform.localScale.x * 0.5f; // Offset a little bit from the edge based on the projectile's width
        xStart.x += width / columns; // offset by a bit from the edge of the object
        xEnd.x -= width / columns;

        yStart.y -= height / rows;

        Vector3 xOffset = new Vector3(1,0,0) * (width / columns);
        Vector3 yOffset = new Vector3(0, 1, 0) * (height / rows);

        //Debug.DrawLine(gameObject.transform.position + xStart + (xOffset * 0) + yStart + (yOffset * 0) + zStart, gameObject.transform.forward * 3, Color.white);
           for(int x = 0; x < columns - 1; x++)
           {
               for(int y = 0; y > -rows + 1; y--)
               {
                   Instantiate(launchObject, gameObject.transform.position + xStart + (xOffset * x) + yStart + (yOffset * y) + zStart, gameObject.transform.rotation);
               yield return new WaitForSeconds(launchInterval);
               }
               //Instantiate(launchObject, gameObject.transform.position, gameObject.transform.rotation);
           }


        //Instantiate(launchObject, gameObject.transform.position + xStart, gameObject.transform.rotation);

        //for(int x = 0; x < columns; x++)
        //{
        //    Vector3 offset = new Vector3(transform.right.x * (x - columns * 0.5f * launchObjectWidth), transform.position.y, transform.position.z);
        //    Instantiate(launchObject, transform.position + offset * (width * 0.1f), transform.rotation);
        //}
    }
}
