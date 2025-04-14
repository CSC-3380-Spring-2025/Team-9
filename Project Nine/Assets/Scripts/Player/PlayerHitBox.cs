using UnityEngine;

// script attaches to 
public class PlayerHitBox : MonoBehaviour

{
    public int AttackDamage = 10;
    public DamageType damageType = DamageType.Normal;
    [Range(0,100)] public int criticalChance = 10;


    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable<int> enemyHealth = collision.GetComponent<IDamageable<int>>();
        if (enemyHealth != null) 
        {
            enemyHealth.TakeDamage( AttackDamage);
        }
    }
}
