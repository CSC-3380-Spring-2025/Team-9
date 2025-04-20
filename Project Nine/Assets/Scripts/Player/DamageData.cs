using UnityEngine;

public enum DamageType { Normal }

public struct DamageData
{
    public readonly int baseDamage;
    public readonly DamageType damageType;
    public readonly bool isCritical;
    // Add other properties as needed

    public DamageData(int damage, DamageType type, bool critical = false)
    {
        baseDamage = damage;
        damageType = type;
        isCritical = critical;
    }
}