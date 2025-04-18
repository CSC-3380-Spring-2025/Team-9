using UnityEngine;

public class BowInteraction : MonoBehaviour
{
    [SerializeField] Bow bow;
    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        inventory.AddItem(bow);
    }
}
