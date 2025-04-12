using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Transform attackPoint; 
    public float attackRange = 0.5f; //the range of attacks is 0.5 units
    public LayerMask enemyLayers; 
    public int attackDamage = 10; //the damage of each attack is 10 units
    private float timeOfNextAttack = 0f; 
    public float attackRate = 1f; //the time between attacks = 1 unit
    // can and should be varied based on weapon type and other variables

    void Update() //receives the attack input and limits speed of attacks based on attack rate
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= timeOfNextAttack)  // When pressing left mouse or Ctrl
            {
                Attack();
                timeOfNextAttack = Time.time + 1f / attackRate;  // Controls the attack speed
            }
        }

    void Attack() //the method that acts out the attack and it's functions
    {
        Debug.Log("Attack function of player activated");
        //detects if enemy is in range of attack, accounting for all variables
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damages all enemies detected
        foreach (Collider2D enemy in hitEnemies)
        {   
            Debug.Log(" hit found");
            MortalEnemy isMortal = enemy.GetComponent<MortalEnemy>();
            if (isMortal != null) // checks if it is a mortal enemy that can be dealt damage
            {
                isMortal.TakeDamage(attackDamage);
            }
        }

        //will include a player attack animation here soon
    }

    void OnDrawGizmosSelected() //displays the range of the attack

    {
        if (attackPoint == null) 
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
