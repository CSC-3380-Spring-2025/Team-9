using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    public GameObject inventoryPanel;

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
