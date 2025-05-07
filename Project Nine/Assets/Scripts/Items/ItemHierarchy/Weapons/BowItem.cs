using Mono.Cecil;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Items/Weapons/Bow")]
public class BowItem : WeaponItems
{
    [Header("Bow Vars")]
    public float maxLoadTime = 2f; //time until arrow auto fires
    public float bufferTime = 0.15f; //minimum time to fire arrow
}
