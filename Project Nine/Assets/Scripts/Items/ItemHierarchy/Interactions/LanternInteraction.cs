using UnityEngine;

public class LanternInteraction : MonoBehaviour
{
    [SerializeField] Lantern lantern;
    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        inventory.AddItem(lantern);
    }
}
