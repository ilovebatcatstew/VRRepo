using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamRot : MonoBehaviour
{

    public GameObject thingToMatchRotation;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.localEulerAngles = new Vector3(
            thingToMatchRotation.transform.eulerAngles.x,
            thingToMatchRotation.transform.eulerAngles.y,
            0f);

        gameObject.transform.position = new Vector3(
            thingToMatchRotation.transform.position.x,
            gameObject.transform.position.y,
            thingToMatchRotation.transform.position.z);
    }
}
