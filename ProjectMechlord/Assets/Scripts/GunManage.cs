using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManage : MonoBehaviour
{
    // the manager to have the gun turrets set up to follow the player as well as rotate and lerp toward where the camera is looking


    public Transform cameraTransform;
    Transform[] gunTransforms;
    // Start is called before the first frame update
    void Start()
    {
        //because this is set up in the parent gameobject,
        //get the transforms of the children
        gunTransforms = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //each frame set the position of the parent GO to be set to the body (currently set to the main camera)
        transform.position = cameraTransform.transform.position;

        //set the rotation of the children to lerp towards where the camera looks
        for (int i = 0; i < gunTransforms.Length; i++)
        {
            gunTransforms[i].rotation = Quaternion.Lerp(gunTransforms[i].rotation, cameraTransform.transform.rotation, 0.01f);
        }


    }
}
