using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float maintainDistance = 5.0f;
    NavMeshAgent agent;

    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerTransform.position - agent.transform.forward * maintainDistance;
    }
}
