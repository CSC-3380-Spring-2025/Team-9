using UnityEngine;

public class BowInteraction : MonoBehaviour
{
    [SerializeField] private BowItem bow;
    [SerializeField] private GameObject bowEquipPrefab;

    private Inventory inventory;
    void Awake()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Inventory");
        if(gameObject == null)
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
        Instantiate(bowEquipPrefab);
    }
}