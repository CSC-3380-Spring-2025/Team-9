using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AugmentCardUI : MonoBehaviour
{
    //public UnityEngine.UI.Image artworkImage; 
    public TMP_Text cardNameText;
    public TMP_Text descriptionText;
    public Button selectButton; 

    private AugmentCard currentAugment; 
    private AugmentSelectionManager manager; 


    public void SetupCard(AugmentCard augment, AugmentSelectionManager mgr) // Set the augment card data in the UI
    {
        currentAugment = augment; // Store the current augment card
        manager = mgr; // Store the reference to the manager

       // artworkImage.sprite = augment.cardArtwork; // Set the artwork image
        cardNameText.text = augment.cardName; // Set the card name text
        descriptionText.text = augment.description; // Set the description text

        selectButton.onClick.RemoveAllListeners(); // Remove any previous listeners from the button
        selectButton.onClick.AddListener(OnSelectClicked);
    }

    private void OnSelectClicked() // Called when the select button is clicked
    {
        manager.OnCardSelected(currentAugment); // Notify the manager that the augment card has been selected
    }
}
