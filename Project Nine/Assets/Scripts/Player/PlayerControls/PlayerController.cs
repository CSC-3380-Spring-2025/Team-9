using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to current scripts
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public PlayerAttacks playerAttack;

    // basic getters and setters
    public int currentHealthPoints
    {
        get { return playerHealth.currentHealthPoints; } // Get the current health points from PlayerHealth
        set { playerHealth.currentHealthPoints = value; } // Set the current health points in PlayerHealth
    }

    public float moveSpeed
    {
        get { return playerMovement.MoveSpeed; } // Get the move speed from PlayerMovement
        set { playerMovement.MoveSpeed = value; } // Set the move speed in PlayerMovement
    }

    public int attackDamage
    {
        get { return playerAttack.attackDamage; } // Get the attack power from PlayerAttack
        set { playerAttack.attackDamage = value; } // Set the attack power in PlayerAttack
    }


    public void Heal(int amount)
    {
        playerHealth.HealDamage(amount); // Heal the player by the specified amount
    }
}
