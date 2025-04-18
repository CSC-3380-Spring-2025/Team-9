using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Door nearbyDoor;
    private BowInteraction nearbyBow;
    void Update()
    {
        if (nearbyBow != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyBow.Interact();
        }
        if (nearbyDoor != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyDoor.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bow"))
        {
            nearbyBow = collision.GetComponent<BowInteraction>();
        }
        if (collision.CompareTag("Door"))
        {
            nearbyDoor = collision.GetComponent<Door>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if(nearbyBow == collision.GetComponent<BowInteraction>())
            {
                nearbyBow = null;
            }
        }
        if(collision.CompareTag("Door"))
        {
            if(nearbyDoor == collision.GetComponent<Door>())
            {
                nearbyDoor = null;
            }
        }
    }
}
