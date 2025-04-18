using UnityEngine;

public class BowInteraction : MonoBehaviour
{
    [SerializeField] private Item bow;
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
        inventory.AddItem(bow);
    }
}
