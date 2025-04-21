using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
  public Transform enemyAttackPoint;
    public float enemyAttackRange = 0.5f;
    public LayerMask playerLayers;
    public int enemyAttackDamage = 10;
    //private float timeOfNextEnemyAttack = 0f;
    public float enemyAttackRate = 0.5f; //rate is halved compared to player attacks to give players more sense of fairness, could change

    public DamageType damageType = DamageType.Normal; 
    [Range(0, 100)] public int criticalChance = 10; // Sets up Critical Chances (change number to change odds)

    // movement 
    public float speed;

    void Update() //receives the attack input and limits speed of attacks based on attack rate
        {
            // if (Input.GetButtonDown("Fire1") && Time.time >= timeOfNextEnemyAttack)  // When pressing left mouse or Ctrl
            // {
            //     Attack();
            //     timeOfNextEnemyAttack = Time.time + 1f / enemyAttackRate;  // Controls the attack speed
            // }
        }

    void Attack() //the method that acts out the attack and it's functions
    {
        
        //detects if enemy is in range of attack, accounting for all variables
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);

        //damages the player when detected
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage( // Sends damage package to player
                new DamageData(
                    enemyAttackDamage, // This is base damage of the enemy
                    damageType, // This can be Normal, Fire, Poison, etc...
                    Random.Range(0, 100) < criticalChance // Critical Chance boolean
                )
            );
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
