using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemySOStatCreate enemyStats;
    public Transform playerTransform;
    NavMeshAgent navAgent;
    

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        navAgent.speed = enemyStats.movespeed;

    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(playerTransform.position); //- agent.transform.forward * 2.0f;

    }
}
