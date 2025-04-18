using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Door nearbyDoor;
    private BowInteraction nearbyBow;
    private SwordInteraction nearbySword;
    private LanternInteraction nearbyLantern;
    void Update()
    {
        if (nearbyLantern != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyLantern.Interact();
            Destroy(nearbyLantern);
        }
        if (nearbySword != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbySword.Interact();
            Destroy(nearbySword);
        }
        if (nearbyBow != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyBow.Interact();
            Destroy(nearbyBow);
        }
        if (nearbyDoor != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyDoor.Interact();
            Destroy(nearbyDoor);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lantern"))
        {
            nearbyLantern = collision.GetComponent<LanternInteraction>();
        }
        if (collision.CompareTag("Sword"))
        {
            nearbySword = collision.GetComponent<SwordInteraction>();
        }
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
        if (collision.CompareTag("Lantern"))
        {
            if (nearbyLantern == collision.GetComponent<LanternInteraction>())
            {
                nearbyLantern = null;
            }
        }
        if (collision.CompareTag("Sword"))
        {
            if (nearbySword == collision.GetComponent<SwordInteraction>())
            {
                nearbySword = null;
            }
        }
        if (collision.CompareTag("Bow"))
        {
            if(nearbyBow == collision.GetComponent<BowInteraction>())
            {
                nearbyBow = null;
            }
        }
        if (collision.CompareTag("Door"))
        {
            if(nearbyDoor == collision.GetComponent<Door>())
            {
                nearbyDoor = null;
            }
        }
    }
}
