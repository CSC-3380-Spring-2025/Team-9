using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Door nearbyDoor;
    void Update()
    {
        if(nearbyDoor != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyDoor.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            nearbyDoor = collision.GetComponent<Door>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Door"))
        {
            if(nearbyDoor == collision.GetComponent<Door>())
            {
                nearbyDoor = null;
            }
        }
    }
}
