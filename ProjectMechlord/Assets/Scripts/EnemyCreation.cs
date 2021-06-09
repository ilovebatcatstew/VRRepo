using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scripting/Enemy", order = 1)]
public class EnemyCreation : ScriptableObject
{
    private GameObject gameObject;
    public float currentHP;
    public float maxHP;
    public NavMeshAgent enemyNav;

    public void Awake()
    {
        
    }



}
