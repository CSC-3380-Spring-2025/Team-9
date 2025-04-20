using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int dmg;

    public void Init(int damage)
    {
        dmg = damage; // Set the damage of the arrow
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Floor"))
        {
            var target = col.GetComponent<IDamageable<int>>(); 
            if (target != null) target.TakeDamage(dmg); // If the arrow hits a damageable object, apply damage
            Destroy(gameObject); // Destroy the arrow after it hits something
        }
    }



    void Start()
    {
        Destroy(gameObject, 3f); // Destroy the arrow after 5 seconds if it doesn't hit anything
    } 

}
