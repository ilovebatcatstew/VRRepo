using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Somewhat functioning projectile.
public class Projectile : MonoBehaviour
{
    AudioSource expAudio;
    public float projectileSpeed = 1.0f;
    public float range = 10.0f;
    public float explosionRadius = 0.5f;

    public ParticleSystem explosion;
    public GameObject smokeTrailPrefab;


    float distanceTravelled = 0.0f;

    Collider collider;

    void Awake()
    {
        expAudio = GetComponent<AudioSource>();
        expAudio.loop = false;
        float explosionSize = explosion.shape.radius;
        explosionSize = explosionRadius;
        collider = gameObject.GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        float length = transform.localScale.z;

        smokeTrailPrefab.transform.localPosition = new Vector3(0, 0, -0.5f);

        Instantiate(smokeTrailPrefab, gameObject.transform);

        //smokeTrailPrefab.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (distanceTravelled >= range)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        smokeTrailPrefab.transform.up = gameObject.transform.up;
        smokeTrailPrefab.transform.forward = gameObject.transform.forward;
        smokeTrailPrefab.transform.right = gameObject.transform.right;

        distanceTravelled += Time.deltaTime * projectileSpeed;



        gameObject.transform.position += gameObject.transform.forward * projectileSpeed;


    }


    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, gameObject.transform.position, explosion.gameObject.transform.rotation);
        expAudio.Play();

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
            if(!other.gameObject.CompareTag("MissilePod"))
            {
                Destroy(gameObject);
            }
        }

    }
}
