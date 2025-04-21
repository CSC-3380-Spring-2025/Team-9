using UnityEngine;

public class ArrowInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private ArrowItem arrow;
    [SerializeField] private GameObject arrowEquipedPrefab;

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
        inventory.AddItem(arrow);
        Instantiate(arrowEquipedPrefab);
    }
}
