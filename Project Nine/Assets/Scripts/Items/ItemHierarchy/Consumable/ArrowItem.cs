using UnityEngine;

[CreateAssetMenu(fileName = "ArrowItem", menuName = "Items/Consumables/Arrow")]
public class ArrowItem : ConsumableItems
{
    [Header("Arrow Vars")]
    public float maxVelocity;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
}
