using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterButton : MonoBehaviour
{

    BasicLaunch launch;
    GameObject[] spawnpos;

    // Start is called before the first frame update
    void Start()
    {
        spawnpos = GameObject.FindGameObjectsWithTag("MissilePod");

        launch.missilePod1 = spawnpos[0].transform;
        launch.missilePod2 = spawnpos[1].transform;
        launch.launchObject = Resources.Load<GameObject>("Prefabs/Projectile");
    }
  private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            launch.FireDaGun();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


  

}
