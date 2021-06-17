using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Somewhat functioning projectile.
public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    public float range = 10.0f;
    public float explosionRadius = 0.5f;



    float distanceTravelled = 0.0f;

    Collider collider;

    void Awake()
    {
        collider = gameObject.GetComponent<BoxCollider>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(distanceTravelled >= range)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        distanceTravelled += Time.deltaTime * projectileSpeed; 

        gameObject.transform.position += gameObject.transform.forward * projectileSpeed;


    }


    private void OnTriggerEnter(Collider other)
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in collisions)
        {
            if (hit.tag == "Enemy")
            {
                Destroy(hit.gameObject);
            }
        }    
        
        if(!other.gameObject.CompareTag("Missile"))
        {
        //    Destroy(gameObject);
            if(!other.gameObject.CompareTag("MissilePod"))
            {
                Destroy(gameObject);
            }
        }

    }
}
