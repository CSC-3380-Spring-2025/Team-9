using UnityEngine;


public class HitBox : MonoBehaviour

{
    public int enemyAttackDamage = 10;
    public DamageType damageType = DamageType.Normal;
    [Range(0,100)] public int criticalChance = 10;


    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable<DamageData> playerHealth = collision.GetComponent<IDamageable<DamageData>>();
        if (playerHealth != null) 
        {
            playerHealth.TakeDamage(
                new DamageData(
                    enemyAttackDamage, // This is base damage of the enemy
                    damageType, // This can be Normal, Fire, Poison, etc...
                    Random.Range(0, 100) < criticalChance // Critical Chance boolean
                )
            );
        }
    }
}
