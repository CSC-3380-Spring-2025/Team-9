using UnityEngine;

public class MortalEnemy : BaseEnemy, IDamageable<int>
{
    [SerializeField] protected FlashDamage _flashCoroutine;
    public int healthPoints = 100;//max health that you start with
    public int currentHealthPoints;//variable health from damage and healing
    protected bool isDead = false;
    

    void Start()
    {
        currentHealthPoints = healthPoints;
        _flashCoroutine = GetComponent<FlashDamage>();
    }

    public void TakeDamage(int damage)//processes damage taken to health
    {
        if (isDead) return;
        currentHealthPoints = Mathf.Max(currentHealthPoints - damage, 0); // Prevent negative health
        _flashCoroutine.CallDamageFlashCorroutine(); // quick flash to indicate that it has taken damage;
        if (currentHealthPoints <= 0)//calls "Die" method to kill the unit
        {
            _flashCoroutine.SetFlashAmount(0);
            Die();
        }
        
    }

    public void HealDamage(int heal)//processes healing received to health
    {
        if (isDead) return;
        currentHealthPoints = Mathf.Min(currentHealthPoints + heal, healthPoints);//heals and ensures no overheal
    }


    virtual public void Die()
    {
        Debug.Log("using inhertied Die function from mortal Enemy class");

        if (isDead) return;
        isDead = true;
        //before destroying, cease all animations, activity, etc.
        Destroy(gameObject);
    }


}
