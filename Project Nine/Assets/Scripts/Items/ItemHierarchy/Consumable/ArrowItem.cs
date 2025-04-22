using UnityEngine;

[CreateAssetMenu(fileName = "ArrowItem", menuName = "Items/Consumables/Arrow")]
public class ArrowItem : ConsumableItems
{
    [Header("Arrow Vars")]
    public float maxArrowVelocity = 10;

    [HideInInspector] public Vector2 arrowDirection;
}
