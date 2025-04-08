using UnityEngine;

public class dmgButtonTest : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    public void SubtractHealth()
    {
        DamageData dmg = new DamageData(10, DamageType.Normal, false);

        playerHealth.TakeDamage(dmg);
    }
    
}
