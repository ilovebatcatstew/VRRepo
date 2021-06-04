using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public Transform[] rocketPoints;
    public GameObject missile;

    public float timeBetweenShots = 0.2f;
    float timer;

    public int volleys = 2;

    bool timerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timerOn)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenShots)
            {
                timerOn = false;
                FireRockets();
            }
        }


    }


    public void FireRockets()
    {
        for (int i = 0; i < rocketPoints.Length; i++)
        {
            Instantiate(missile, gameObject.transform.position, gameObject.transform.rotation);
        }
        volleys -= 1;
        if (volleys != 0)
        {
            timerOn = true;
        }
    }
}
