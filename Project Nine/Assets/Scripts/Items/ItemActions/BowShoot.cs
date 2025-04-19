using Unity.VisualScripting;
using UnityEngine;

public class BowShoot : MonoBehaviour
{
    private Inventory inventory;
    private InventoryItem mainHandItem;
    private BowItem bow;
    private ArrowItem arrow;

    private float startTime;

    private bool isHolding = false;
    private bool inMainHand = false;

    void Start()
    {
        Debug.Log("It Started");
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        mainHandItem = inventory._inventorySlots[0].GetComponentInChildren<InventoryItem>();
        if (mainHandItem == null || !(mainHandItem.item is BowItem bowItem))
        {
            bow = null;
            inMainHand = false;
            return;
        }
        bow = bowItem;
        inMainHand = true;

        if (bow != null && inMainHand)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                startTime = 0;
                LoadArrow();
            }
            if(isHolding && HeldLongerThanMaxTime())
            {
                ReleaseArrow();
            }
            if(Input.GetKeyUp(KeyCode.L) && isHolding)
            {
                ReleaseArrow();
            }
        }

    }
    private void LoadArrow()
    {
        startTime = Time.time;
        isHolding = true;
        Debug.Log("ArrowLoading");
    }
    private bool HeldLongerThanMaxTime()
    {
        return Time.time - startTime >= bow.maxLoadTime;
    }
    private bool HeldLessThanMinTime()
    {
        return Time.time - startTime <= bow.bufferTime;
    }
    private void ReleaseArrow()
    {
        if (HeldLongerThanMaxTime())
        {
            Debug.Log("HeldForTooLong");

        }
        else if (HeldLessThanMinTime())
        {
            Debug.Log("NotHeldLongEnough");
        }
        else
        {
            Debug.Log("ArrowFired");
        }
        isHolding = false;
    }
}