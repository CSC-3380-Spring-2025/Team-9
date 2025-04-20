using UnityEngine;

public class LanternInteraction : MonoBehaviour
{
    [SerializeField] private Item lantern;
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
        inventory.AddItem(lantern);
    }
}
