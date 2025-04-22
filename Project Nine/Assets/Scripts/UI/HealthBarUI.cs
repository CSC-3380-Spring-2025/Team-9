using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthBarImage; // Reference to the health bar image
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script



    void Update()
    {
        float healthPercentage = (float)playerHealth.currentHealthPoints / playerHealth.healthPoints; // Calculate the health percentage
        healthBarImage.fillAmount = healthPercentage; // Update the health bar fill amount
    }
}
