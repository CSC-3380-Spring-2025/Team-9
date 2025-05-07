using UnityEngine;

[CreateAssetMenu(fileName = "ArrowItem", menuName = "Items/Consumables/Arrow")]
public class ArrowItem : ConsumableItems
{
    [Header("Arrow Vars")]
    public float maxArrowVelocity = 30;

    [HideInInspector] 
    public Vector2 arrowDirection;
    [HideInInspector]
    public int damage = 20;
}
