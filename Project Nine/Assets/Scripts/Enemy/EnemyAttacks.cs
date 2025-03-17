using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public float enemyAttackRange = 0.5f;
    public LayerMask playerLayers;
    public int enemyAttackDamage = 10;
    private float timeOfNextEnemyAttack = 0f;
    public float enemyAttackRate = 0.5f; //rate is halved compared to player attacks to give players more sense of fairness, could change

    void Update() //receives the attack input and limits speed of attacks based on attack rate
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= timeOfNextEnemyAttack)  // When pressing left mouse or Ctrl
            {
                Attack();
                timeOfNextEnemyAttack = Time.time + 1f / enemyAttackRate;  // Controls the attack speed
            }
        }

    void Attack() //the method that acts out the attack and it's functions
    {
        
        //detects if enemy is in range of attack, accounting for all variables
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);

        //damages the player when detected
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyAttackDamage);
        }
    } 

    void OnDrawGizmosSelected() //displays the range of the attack

    {
        if (enemyAttackPoint == null) 
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}
