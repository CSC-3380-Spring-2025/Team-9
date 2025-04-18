using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AugmentSelectionManager : MonoBehaviour
{
    [Header("Augment pool")]
    public AugmentCard[] allAugmentCards; // Array of available augment cards, to be populated in the inspector

    [Header("UI references")]
    public GameObject cardUIPrefab; // Prefab for the augment card UI element
    public Transform cardSpawnParent; // Where to place the card UI objects
    public Button rerollButton; // Button to reroll the augment cards



    // Track the current three choices in case user rerolls
    private List<AugmentCard> currentOptions = new List<AugmentCard>();
    private bool hasRerolled = false; 
    private PlayerController player;


    public void ShowAugmentCards(PlayerController p) // Show the augment cards in the UI
    {
        player = p;
        hasRerolled = false; // Reset reroll state

        // clear previusly shown cards
        foreach (Transform child in cardSpawnParent)
        {
            Destroy(child.gameObject);
        }


        // pick random valid cards
        currentOptions = GetRandomAugmentCards(3); // Get 3 random augment cards


        // spawn the cards in the UI
        foreach (AugmentCard augment in currentOptions)
        {
            GameObject cardObj = Instantiate(cardUIPrefab, cardSpawnParent);
            AugmentCardUI cardUI = cardObj.GetComponent<AugmentCardUI>();
            cardUI.SetupCard(augment, this); // Set the augment card data in the UI
        }


        // enable the reroll button
       // rerollButton.gameObject.SetActive(!hasRerolled); // Show the reroll button if not already rerolled

        Debug.Log($"Spawning {currentOptions.Count} cards...");
    }


    // Called when player clicks a card
    public void OnCardSelected(AugmentCard chosenAugment)
    {
        
        // Apply the chosen augment to the player
        chosenAugment.ApplyEffect(player.GetComponent<PlayerHealth>()); // Apply the augment effect to the player

        // Mark the augment as chosen in the inventory
        AugmentInventory.Instance.MarkAugmentAsChosen(chosenAugment.augmentID);

        // Hide the augment selection UI
        gameObject.SetActive(false);
    } 


    // Called by reroll button
    public void OnRerollPress()
    {
        if (!hasRerolled)
        {
            hasRerolled = true;
            ShowAugmentCards(player); // Show the augment cards again
        }
    }


    private List<AugmentCard> GetRandomAugmentCards(int amount)
    {
        List<AugmentCard> randomCards = new List<AugmentCard>();

        // get all valid cards that have not been chosen yet
        foreach (AugmentCard card in allAugmentCards)
        {
            if (!AugmentInventory.Instance.HasAugmentBeenChosen(card.augmentID))
            {
                randomCards.Add(card);
            }
        }

        // if less than requested, return all valid cards
        if (randomCards.Count < amount)
        {
            return randomCards;
        }

        // otherwise, pick random cards from the valid pool
        List<AugmentCard> selectedCards = new List<AugmentCard>();
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, randomCards.Count);
            selectedCards.Add(randomCards[randomIndex]);
            randomCards.RemoveAt(randomIndex); // Remove the selected card to avoid duplicates
        }
        return selectedCards;
    }



}
