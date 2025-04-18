using UnityEngine;

public class BoneProjectile : MonoBehaviour
{
    public int   damage   = 10;
    public float lifetime = 10f;

    void Start() => Destroy(gameObject, lifetime);

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Floor") || col.collider.CompareTag("Boss")) return;

        var dmgTarget = col.collider.GetComponent<IDamageable<DamageData>>();
        if (dmgTarget != null)
            dmgTarget.TakeDamage(new DamageData(damage, DamageType.Normal, false));
    }
}
