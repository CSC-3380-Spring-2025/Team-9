using UnityEngine;

public class Snail : BaseEnemy // immortal enemy
{
    void Update()
    {
        Attack();
    }
    void Attack() {

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);

        //damages the player when detected
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Found player");
            player.GetComponent<PlayerHealth>().Die();
        }

    }
}
