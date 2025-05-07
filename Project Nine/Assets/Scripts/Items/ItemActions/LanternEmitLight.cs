using UnityEngine;

public class LanternEmitLight : MonoBehaviour
{
    private Inventory inventory;
    private InventoryItem offHandItem;
    private InventoryItem mainHandItem;

    private LanternItem lantern;

    private bool inHand;

    void Start()
    {
        Debug.Log("Lantern started Emiting light");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {

    }
    private void CheckInHand()
    {
        mainHandItem = inventory._inventorySlots[0].GetComponentInChildren<InventoryItem>();
        offHandItem = inventory._inventorySlots[1].GetComponentInChildren<InventoryItem>();

        bool inMainHand = true;
        bool inOffHand = true;

        if (mainHandItem == null || !(mainHandItem.item is LanternItem LanternMain))
        {
            inMainHand = false;
        }
        if (offHandItem == null || !(offHandItem.item is LanternItem lanternOff))
        {
            inOffHand = false;
        }
        inHand = inMainHand || inOffHand;
    }
}
