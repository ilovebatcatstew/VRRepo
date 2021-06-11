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


    void Awake()
    {
        mouse = Mouse.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletLines = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireCannons()
    {

        int layerMask = 1 << 8;

        layerMask = ~layerMask;
        RaycastHit hit;
        
        if (Physics.Raycast(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward, out hit, 10, layerMask))
        {
            ShootLineFromTargetPosition(gunTransform1.position + (gunTransform1.forward * (gunTransform1.localScale.z * 0.5f)), gunTransform1.forward, lineMaxLength);
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

            ShootLineFromTargetPosition(gunTransform2.position + (gunTransform2.forward * (gunTransform2.localScale.z * 0.5f)), gunTransform2.forward, lineMaxLength);
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

        bulletLines.SetPosition(0, targetPosition);
        bulletLines.SetPosition(1, endPosition);

        
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
