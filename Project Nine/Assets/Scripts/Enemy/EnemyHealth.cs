using UnityEngine;
// shouldn't be needed anymore but leaving here for now in case we need to go back
public class EnemyHealth : MonoBehaviour
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
        if (isDead) return;
        currentHealthPoints = Mathf.Max(currentHealthPoints - damage, 0); // Prevent negative health
        if (currentHealthPoints <= 0)//calls "Die" method to kill the unit
        {
            Die();
        }
    }

    public void HealDamage(int heal)//processes healing received to health
    {
        if (isDead) return;
        currentHealthPoints = Mathf.Min(currentHealthPoints + heal, healthPoints);//heals and ensures no overheal
    }


    void Die()
    {
        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
        Destroy(gameObject);
    }

}
