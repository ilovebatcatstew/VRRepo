using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hitscan : MonoBehaviour
{
    public float weaponRange = 10.0f;

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
            if (Physics.Raycast(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward, out hit, weaponRange, layerMask))
            {
                Debug.DrawRay(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward * weaponRange, Color.red);
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                Debug.DrawRay(gunTransform.position + (gunTransform.forward * (gunTransform.localScale.z * 0.5f)), gunTransform.forward * weaponRange, Color.white);
            }
        }
    }
}
