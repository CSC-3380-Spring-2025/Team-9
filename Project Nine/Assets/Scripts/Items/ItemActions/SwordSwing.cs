using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private Inventory inventory;
    private InventoryItem mainHandItem;
    private SwordItem sword;
    float nextSwingTime;
    private bool inMainHand;

    void Start()
    {
        Debug.Log("Sword Swing Script Started");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        mainHandItem = inventory._inventorySlots[0].GetComponentInChildren<InventoryItem>();
        if (mainHandItem == null || !(mainHandItem.item is SwordItem swordItemType))
        {
            inMainHand = false;
            sword = null;
            return;
        }
        sword = swordItemType;
        inMainHand = true;

        if (sword != null && inMainHand && Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextSwingTime)
        {
            SwingSword();
            nextSwingTime = Time.time + sword.swingCooldown;
        }
    }

    private void SwingSword()
    {
        Debug.Log("Sword is swung");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            var isMortal = enemy.GetComponent<IDamageable<int>>();
            if (isMortal != null)
            {
                isMortal.TakeDamage((int)sword.dmg);
            }
        }
    }
}
