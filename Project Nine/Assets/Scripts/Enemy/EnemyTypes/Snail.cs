using Pathfinding;
using UnityEngine;

public class Snail : BaseEnemy // immortal enemy
{
    AIDestinationSetter aiDestScript;

    void Start()
    {
        aiDestScript = GetComponent<AIDestinationSetter>();
        aiDestScript.target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Attack(); 
    }
    void Attack() {


        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);

        //damages the player when detected
        foreach (Collider2D player in hitPlayers)
        {
         
            aiDestScript.enabled = false; // stop moving towards/pushing the player when it has attacked it.

//            player.GetComponent<PlayerHealth>().Die();
        }

    }
}
