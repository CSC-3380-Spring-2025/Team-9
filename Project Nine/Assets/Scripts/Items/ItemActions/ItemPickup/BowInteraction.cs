using UnityEngine;

public class BowInteraction : MonoBehaviour, IInteractable  
{
    [SerializeField] private BowItem bow;
    [SerializeField] private GameObject bowEquipPrefab;

    private Inventory inventory;

    void Awake()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Inventory");
        if (gameObject == null)
        {
            Debug.Log("No Game Object Found");
            return;
        }
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        if (inventory == null) return;
        inventory.AddItem(bow);
        GameObject bowEquipped = Instantiate(bowEquipPrefab);
        if (inventory != null)
        {
            bowEquipped.transform.SetParent(inventory.transform); // set the inventory as the parent so that this cab be detroyed when the inventory is destroyed
        }
        else {
            Debug.Log("Inventory is null");
        }
    }
}