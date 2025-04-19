using UnityEngine;

public class AugmentTestButton : MonoBehaviour
{
    public AugmentSelectionManager augmentManager;
    public PlayerController player;

    public void TriggerAugments()
    {
        if (augmentManager != null && player != null)
        {
            augmentManager.gameObject.SetActive(true); 
            augmentManager.ShowAugmentCards(player);
        }
        else
        {
            Debug.LogError("AugmentSelectionManager or PlayerController is not assigned in the inspector.");
        }
    } 
}
