﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterButton : MonoBehaviour
{

    public GridLaunch launch;
    public GridLaunch launch1;
    //public GameObject[] spawnpos;

    public bool fire = false;
    // Start is called before the first frame update
    void Start()
    {
        //launch = GetComponent<GridLaunch>();
       // spawnpos = GameObject.FindGameObjectsWithTag("MissilePod");

        //launch.missilePod1 = spawnpos[0].transform;
        //launch.missilePod2 = spawnpos[1].transform;
        //launch.launchObject = Resources.Load<GameObject>("Prefabs/Projectile");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            launch.LaunchMissiles();
            launch1.LaunchMissiles();
            
        }
        
    }
    void Update()
    {
        if (fire)
        {
            launch.LaunchMissiles();
            launch1.LaunchMissiles();
            fire = false;
        }
    }
    // Update is called once per frame





}
