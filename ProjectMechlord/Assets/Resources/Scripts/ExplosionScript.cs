using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for managing the explosion until I find a better way of managing the particle effect
public class ExplosionScript : MonoBehaviour
{
    public float explosionDuration = 0.0f;
    float timer = 0.0f;


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
        if(timer > explosionDuration)
        {
            Destroy(gameObject);
        }
    }
}
