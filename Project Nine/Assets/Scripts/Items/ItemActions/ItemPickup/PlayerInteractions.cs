using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private IInteractable interactable;

    void Update()
    {
        if (interactable != null && Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact();
            Destroy(((MonoBehaviour)interactable).gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactable = collision.GetComponent<IInteractable>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            if (interactable == collision.GetComponent<IInteractable>())
            {
                interactable = null;
            }
        }
    }
}
