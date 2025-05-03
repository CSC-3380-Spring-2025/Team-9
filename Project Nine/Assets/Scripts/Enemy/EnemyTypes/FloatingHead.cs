using UnityEngine;

// enemy that slowly creeps up on player and then explodes when close to him
public class FloatingHead : BaseEnemy//  MortalEnemy, IDamageable<int>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    private Animator anim;
    public int threshold = 4; // didtance from player at which to explode
    

    void Start()
    {
        anim  = gameObject.GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
    //  enemyAttackRange = 7; // blow up radius
    //  enemyAttackDamage = 30;
    //  currentHealthPoints = healthPoints;
    //  _flashCoroutine = GetComponent<FlashDamage>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null) return;
        float distance = Vector2.Distance(transform.position , player.transform.position);    
        if (distance <= threshold)
        {
            Explode();
            //Destroy(gameObject);
        }    
    }

    void Explode()
    {
        // deal damage to player
        
        // Attack();
        anim.SetBool("isExploding", true);
        Debug.Log("Exploded");
    }

    // The damage of the explosion radius will be handled in an emoty child object that has a collider which grows as the animation of the raidius grows

    public void Die()
    {
        Destroy(gameObject, 0.2f);
    }


    void OnDrawGizmosSelected() //displays the range of the attack

    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, threshold);
    }
    
}
