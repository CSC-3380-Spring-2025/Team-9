using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour, IDamageable<int>
{

    public int maxHealth = 300;
    public System.Action OnDeath; // Action to be called on death
    int currentHealth;

    TextMeshPro hpLabel;

    public bool IsStageTwo => currentHealth <= maxHealth / 2; // Check if the boss is in stage two



    void Awake()
    {
        currentHealth = maxHealth; 
        hpLabel = GetComponentInChildren<TextMeshPro>(); 
        if (hpLabel == null) hpLabel.text = currentHealth.ToString(); 
    }



    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - Mathf.Abs(damage), 0); // Ensure health doesn't go below 0

        if (hpLabel != null) hpLabel.text = currentHealth.ToString(); // Update the health label

        if (currentHealth <= 0)
        {
            Die(); // Call the die method
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject); 
    }
}