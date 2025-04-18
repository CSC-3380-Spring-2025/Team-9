using TMPro;
using UnityEngine;

public abstract class WeaponItem : Item
{
    public int damage;
    public float rateOfAttack;

    public abstract void Use();
}
