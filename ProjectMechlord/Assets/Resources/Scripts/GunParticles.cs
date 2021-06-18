using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParticles : MonoBehaviour
{
    ParticleSystem gunSparks;
    public float effectDuration = 0.5f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        gunSparks = gameObject.GetComponent<ParticleSystem>();
        gunSparks.startLifetime = effectDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > effectDuration)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

    }


}
