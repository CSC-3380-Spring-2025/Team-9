using UnityEngine;
using UnityEngine.UIElements;

public class BowWeapon : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab for the arrow
    public float arrowSpeed = 20f; // Speed of the arrow
    public int arrowDamage = 10; // Damage of the arrow
    public float fireRate = 2f; // Rate of fire in seconds
    private float nextShot = 0f; // Time when the bow can fire again




    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShot)
        {
            Shoot();
            nextShot = Time.time + 1f /fireRate;
        }
    }


    void Shoot()
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().linearVelocity = dir * arrowSpeed; // Set the velocity of the arrow
        arrow.GetComponent<Arrow>().Init(arrowDamage); // Initialize the arrow with damage
    }



}
