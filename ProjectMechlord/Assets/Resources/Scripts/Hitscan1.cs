using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hitscan1 : MonoBehaviour
{
    public Transform gunTransform1;
    public Transform gunTransform2;

    public GameObject gunParticleEffect;


    Mouse mouse;

    public LineRenderer bulletLines1;
    public LineRenderer bulletLines2;
    public float lineWidth = 0.1f;
    public float lineMaxLength = 10f;

    AudioSource gunAudio;

    public bool fire = false;

    void Awake()
    {
        mouse = Mouse.current;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand" || fire)
        {
            FireCannons();

        }
    }
    void Update()
    {
        if (fire)
        {
            FireCannons();
           // fire = false;
        }
        //VladsGunShoot();
    }

    public void FireCannons()
    {
        

        gunAudio.Play();
        int layerMask = 1 << 8;

        layerMask = ~layerMask;
        RaycastHit hit;
        ShootLineFromTargetPosition1(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward, lineMaxLength);
        ShootLineFromTargetPosition2(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward, lineMaxLength);

        Instantiate(gunParticleEffect, gunTransform1);
        Instantiate(gunParticleEffect, gunTransform2);
        VladsGunShoot();


        StartCoroutine(DestroyLineAfterLifetime());
    }

    void ShootLineFromTargetPosition1(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }
        Vector3 temp = new Vector3(0, 0, 15.0f);
        bulletLines1.positionCount = 2;
        bulletLines1.SetPosition(0, targetPosition);
        bulletLines1.SetPosition(1, endPosition);
       



    }
    void ShootLineFromTargetPosition2(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit))
        {
            endPosition = raycastHit.point;
            Debug.Log(endPosition);
        }
        Vector3 temp = new Vector3(0, 0, 15.0f);
        bulletLines2.positionCount = 2;

        bulletLines2.SetPosition(0, targetPosition);
        bulletLines2.SetPosition(1, endPosition);



    }
    private IEnumerator DestroyLineAfterLifetime()
    {
        yield return new WaitForSeconds(0.25f);

        DestroyLine();
    }
    private void DestroyLine()
    {
        bulletLines1.positionCount = 0;
        bulletLines2.positionCount = 0;

    }

    public void VladsGunShoot() // Reference material 
    {
        RaycastHit testHit;

        int layerMask = 1 << 8;

        layerMask = ~layerMask;


        Physics.Raycast(gunTransform1.position, gunTransform1.forward, out testHit);
        if(Physics.Raycast(gunTransform1.position, gunTransform1.forward, out testHit))
        {
            if(testHit.collider.tag == "Enemy")
            {
                Debug.DrawRay(gunTransform1.position, gunTransform1.forward * 100f, Color.red);
                Destroy(testHit.collider.gameObject);
            }
            else
            {
                Debug.DrawRay(gunTransform1.position, gunTransform1.forward * 100f, Color.yellow);
            }
        }
        else
        {
            Debug.DrawRay(gunTransform1.position, gunTransform1.forward * 100f, Color.green);
        }
        
        Physics.Raycast(gunTransform2.position, gunTransform2.forward, out testHit);
        if(Physics.Raycast(gunTransform2.position, gunTransform2.forward, out testHit))
        {
            if(testHit.collider.tag == "Enemy")
            {
                Debug.DrawRay(gunTransform2.position, gunTransform2.forward * 100f, Color.red);
                Destroy(testHit.collider.gameObject);
            }
            else
            {
                Debug.DrawRay(gunTransform2.position, gunTransform2.forward * 100f, Color.yellow);
            }
        }
        else
        {
            Debug.DrawRay(gunTransform2.position, gunTransform2.forward * 100f, Color.green);
        }
    }
}
