using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItems", menuName = "Items/Consumables")]
public class ConsumableItems : Item
{
    [Header("Consumable Vars")]
    public int maxStackNum;

    protected int stackSize;
}
