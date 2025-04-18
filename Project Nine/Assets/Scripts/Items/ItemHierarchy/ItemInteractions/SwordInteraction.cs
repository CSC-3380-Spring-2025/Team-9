using UnityEngine;

public class SwordInteraction : MonoBehaviour
{
    [SerializeField] Sword sword;
    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        inventory.AddItem(sword);
    }
}
