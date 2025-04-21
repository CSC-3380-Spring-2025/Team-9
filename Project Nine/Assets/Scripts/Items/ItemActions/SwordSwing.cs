using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private Inventory inventory;
    private InventoryItem mainHandItem;

    private SwordItem sword;

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

        if (sword != null && inMainHand && Input.GetKeyDown(KeyCode.Mouse0))
        {
            SwingSword();
        }
    }
    private void SwingSword()
    {
        Debug.Log("Sword is swung");
    }
}
