using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hitscan : MonoBehaviour
{
    Transform gunTransform;
    Mouse mouse;

    void Awake()
    {
        gunTransform = gameObject.transform;
        mouse = Mouse.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.leftButton.isPressed)
        {
            int layerMask = 1 << 8;

            layerMask = ~layerMask;
            RaycastHit hit;
            if (Physics.Raycast(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward, out hit, 10, layerMask))
            {
                Debug.DrawRay(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward * 10, Color.red);
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                Debug.DrawRay(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward * 10, Color.white);
            }
        }
    }
}
