using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float range = 10.0f;
    public float projectileSpeed = 1.0f;
    public int damage = 1;

    float distanceTravelled = 0.0f;

    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(distanceTravelled >= range)
        {
            Destroy(gameObject);
        }        
    }

    private void FixedUpdate()
    {
        distanceTravelled += projectileSpeed * Time.deltaTime;
        transform.position += transform.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Some kind of take damage function or health variable that gets subtracted from
            Destroy(gameObject);
        }

        if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
