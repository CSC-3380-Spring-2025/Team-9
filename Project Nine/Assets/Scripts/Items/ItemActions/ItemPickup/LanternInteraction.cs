using UnityEngine;

public class LanternInteraction : MonoBehaviour
{
    [SerializeField] private LanternItem lantern;
    [SerializeField] private GameObject lanternEquipedPrefab;

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
        inventory.AddItem(lantern);
        Instantiate(lanternEquipedPrefab);
    }
}
