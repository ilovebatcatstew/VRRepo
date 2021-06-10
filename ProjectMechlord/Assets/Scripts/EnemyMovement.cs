using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.destination = playerTransform.position; //- agent.transform.forward * 2.0f;
    }
}
