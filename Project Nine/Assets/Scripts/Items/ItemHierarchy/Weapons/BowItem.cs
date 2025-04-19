using Mono.Cecil;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Items/Bow")]
public class BowItem : Item
{
    private Inventory inventory;

    public float maxLoadTime = 2f; //time until arrow auto fires
    public float bufferTime = 0.15f; //minimum time to fire arrow
    public float maxDamage = 10; //max damage

}
