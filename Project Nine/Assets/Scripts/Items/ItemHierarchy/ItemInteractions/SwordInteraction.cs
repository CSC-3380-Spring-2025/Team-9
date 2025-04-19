using UnityEngine;

public class SwordInteraction : MonoBehaviour
{
    [SerializeField] private Item sword;
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
        inventory.AddItem(sword);
    }
}
