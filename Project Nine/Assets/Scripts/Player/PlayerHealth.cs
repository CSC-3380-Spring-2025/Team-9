using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoints = 100;//max health that you start with
    public int currentHealthPoints;//variable health from damage and healing
    private bool isDead = false;

    void Start()
    {
        currentHealthPoints = healthPoints;
    }

    public void TakeDamage(int damage)//processes damage taken to health
    {
        currentHealthPoints = Mathf.Max(currentHealthPoints - damage, 0); //Prevent negative health
        if (currentHealthPoints <= 0)//calls "Die" method to kill the player
        {
            Die();
        }
    }

    public void HealDamage(int heal)//processes healing received to health
    {
        currentHealthPoints = Mathf.Min(currentHealthPoints + heal, healthPoints);//heals and ensures no overheal
    }


    void Die()
    {
        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
        //Game over screen implemented, items lost, etc.
        Destroy(gameObject);
    }
}
