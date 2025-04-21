using UnityEngine;

public class SwordInteraction : MonoBehaviour
{
    [SerializeField] private SwordItem sword;
    [SerializeField] private GameObject swordEquipedPrefab;

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
        inventory.AddItem(sword);
        Instantiate(swordEquipedPrefab);
    }
}
