using UnityEngine;

// enemy that slowly creeps up on player and then explodes when close to him
public class FloatingHead : BaseEnemy//  MortalEnemy, IDamageable<int>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    public int threshold = 4; // didtance from player at which to explode

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    //  enemyAttackRange = 7; // blow up radius
    //  enemyAttackDamage = 30;
    //  currentHealthPoints = healthPoints;
    //  _flashCoroutine = GetComponent<FlashDamage>();
    }
    

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position , player.transform.position);    
        if (distance <= threshold)
        {
            Explode();
            Destroy(gameObject);
        }    
    }

    void Explode()
    {
        // deal damage to player
        Attack();
        Debug.Log("Exploded");

    }
}
