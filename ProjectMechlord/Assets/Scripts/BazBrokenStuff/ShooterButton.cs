using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterButton : MonoBehaviour
{

    public RocketLauncher launcher1;
    public RocketLauncher launcher2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            launcher1.FireRockets();
            launcher2.FireRockets();
        }
    }

}
