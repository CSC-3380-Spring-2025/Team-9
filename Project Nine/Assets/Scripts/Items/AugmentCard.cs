using UnityEngine;

[CreateAssetMenu(fileName = "New Augment Card", menuName = "Augments/Augment Card")]
public class AugmentCard : ScriptableObject
{
    [Header("Unique ID")]
    public string augmentID; // Unique ID for the augment card

    [Header("Basic Info")]
    public string cardName;
    [TextArea]
    public string description; // Description of the augment card
    public Sprite cardArtwork; // Artwork for the augment card

    //example for test
    public int healthBonus;


    public void ApplyEffect(PlayerHealth player)
    {
        player.healthPoints += healthBonus; // Apply the health bonus to the player
        player.currentHealthPoints += healthBonus; // Update the current health points of the player
    }
}
