using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hitscan1 : MonoBehaviour
{
    public Transform gunTransform1;
    public Transform gunTransform2;
    
    Mouse mouse;

    public LineRenderer bulletLines;
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
        bulletLines = GetComponent<LineRenderer>();
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
        }
    }

    public void FireCannons()
    {
        

        gunAudio.Play();
        int layerMask = 1 << 8;

        layerMask = ~layerMask;
        RaycastHit hit;
        ShootLineFromTargetPosition(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward, lineMaxLength);
        ShootLineFromTargetPosition(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward, lineMaxLength);

        if (Physics.Raycast(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward, out hit, 10, layerMask))
        {
            Debug.DrawRay(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward * 10, Color.red);
            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward * 10, Color.white);
        }

        RaycastHit hit2;
        if (Physics.Raycast(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward, out hit2, 10, layerMask))
        {

            Debug.DrawRay(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward * 10, Color.red);
            if (hit2.collider.tag == "Enemy")
            {
                Destroy(hit2.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward * 10, Color.white);
        }

        StartCoroutine(DestroyLineAfterLifetime());
    }

    void ShootLineFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }
        Vector3 temp = new Vector3(0, 0, 15.0f);
        bulletLines.SetPosition(0, targetPosition);
        bulletLines.SetPosition(1, (targetPosition += temp));

        
    }
    private IEnumerator DestroyLineAfterLifetime()
    {
        yield return new WaitForSeconds(0.5f);

        DestroyLine();
    }
    private void DestroyLine()
    {
        bulletLines.positionCount = 0;
    }
}
