using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void Pickup(Inventory inventory)
    {
        if (inventory.AddItem(item))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

}
