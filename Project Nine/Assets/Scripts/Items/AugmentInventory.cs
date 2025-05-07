using System.Collections.Generic;
using UnityEngine;

public class AugmentInventory : MonoBehaviour
{
    public static AugmentInventory Instance; // Singleton instance of the AugmentInventory

    // keep track of augment ids so they dont get shown twice
    private HashSet<string> chosenAugmentIDs = new HashSet<string>();



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkAugmentAsChosen(string augmentID)
    {
        chosenAugmentIDs.Add(augmentID);
    }

    public bool HasAugmentBeenChosen(string augmentID)
    {
        return chosenAugmentIDs.Contains(augmentID);
    }


}
