using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public Transform projectileSpawnPostion;
    public float fireDelay = 5.0f;
    public GameObject enemyProjectile;

    float timer = 0.0f;

    NavMeshAgent enemy;

    float distanceFromPlayer;

    // Maybe put a vector3 here that stores the facing of the enemy agent and also get the vector between the enemy and the player to get the direction

    Vector3 facing;
    Vector3 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer = Vector3.Distance(transform.position, enemy.destination);

       // Debug.Log("The distance of the enemy from the player is: " + distanceFromPlayer);

        facing = transform.forward;
        directionToPlayer = enemy.destination - enemy.transform.position;

        directionToPlayer =  Vector3.Normalize(directionToPlayer);


       // Debug.Log("The enemy is facing: " + facing);
       // Debug.Log("The direction to the player is: " + directionToPlayer);
        

        // This thing needs to work only for two axes,  (ie the x and z axes)
        float enemyFacingTowardPlayer = Vector3.Dot(facing, directionToPlayer); // Experimental, could be broken and make things not work
                                                                                // But essentially this should determin whether the enemy is facing the player

        //Debug.Log("The dot Product of the enemy's facing and the direction to the player is:" + enemyFacingTowardPlayer);

        // The 'distanceFromPlayer' portion should intelligently check how far away from the player (or destination)
        // The 'enemyFacingTowardPlayer' portion is the logic that checks whether the enemy is facing the player as stated above, though it could not work properly and requires a bit of testing.
        if (timer > fireDelay && distanceFromPlayer < enemy.stoppingDistance && enemyFacingTowardPlayer > 0.9f)
        {
            ShootProjectile();
            timer = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    public void ShootProjectile()
    {
        // Seems simple enough, probably needs more work
        Instantiate(enemyProjectile, projectileSpawnPostion.position, projectileSpawnPostion.rotation);
    }
}
