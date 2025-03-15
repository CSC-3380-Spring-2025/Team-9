using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoScript : MonoBehaviour
{
    public Inventory _inventoryManager;
    public Item[] _itemsToPickup;

    public void PickUpItems(int id)
    {
        // Checks if the inventory is full
       bool result = _inventoryManager.AddItem(_itemsToPickup[id]);
         if(result)
         {
              Debug.Log("Item added to inventory");
         }
         else
         {
              Debug.Log("Inventory is full");
         }
    }
}
