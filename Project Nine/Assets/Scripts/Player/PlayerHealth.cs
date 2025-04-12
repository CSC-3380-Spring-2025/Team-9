using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable<DamageData>
{
    public int healthPoints = 100;//max health that you start with
    public int currentHealthPoints;//variable health from damage and healing
    private bool isDead = false;

    void Start()
    {
        currentHealthPoints = healthPoints;
    }

    public void TakeDamage(DamageData damage)//processes damage taken to health
    {
        int calculatedDamage = CalculateDamage(damage);
        currentHealthPoints = Mathf.Max(currentHealthPoints - calculatedDamage, 0); //Prevent negative health
        if (currentHealthPoints <= 0)//calls "Die" method to kill the player
        {
            Die();
        }
    }
    private int CalculateDamage(DamageData damage)
    {
        int result = damage.baseDamage;

        if (damage.isCritical)
        {
            result = (int)(result * 1.5);
        }

        return result;
    }

    public void HealDamage(int heal)//processes healing received to health
    {
        currentHealthPoints = Mathf.Min(currentHealthPoints + heal, healthPoints);//heals and ensures no overheal
    }


    public void Die()
    {
        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
        //Game over screen implemented, items lost, etc.
        Destroy(gameObject);
    }


}
