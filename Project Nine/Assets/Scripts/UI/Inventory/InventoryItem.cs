using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Item item;


    // This function is called when the object becomes enabled and active
    public void InitializeItem(Item newItem){
        item = newItem;
        image.sprite = newItem._image;
        RefreshCount();
    }

    // This function refreshes the count of the item
    public void RefreshCount(){
        countText.text = count.ToString();
    }

    // This function is called when the user starts dragging the item
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    // This function is called every frame while the user is dragging the item
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Called when the user stops dragging (also handles dropping).
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        GameObject hoveredObject = eventData.pointerEnter;
        if (hoveredObject == null || hoveredObject.transform.parent == null)
        {
            // Dropped in an invalid place
            ReturnToOriginalSlot();
            return;
        }

        InventorySlot targetSlot = hoveredObject.transform.parent.GetComponent<InventorySlot>();
        InventoryItem existingItem = hoveredObject.GetComponent<InventoryItem>();

        if (targetSlot == null)
        {
            // Not a valid slot
            ReturnToOriginalSlot();
            return;
        }

        // If there's an item in the target slot, swap them; otherwise move to the empty slot.
        if (existingItem != null)
        {
            SwapItems(existingItem);
        }
        else
        {
            MoveItemToSlot(targetSlot);
        }

        // Always reset local position after dropping
        transform.localPosition = Vector3.zero;
    }

    // Swap places with the other item.
    private void SwapItems(InventoryItem otherItem)
    {
        Transform otherParent = otherItem.transform.parent;

        // Move this item into the other's slot
        transform.SetParent(otherParent);
        transform.localPosition = Vector3.zero;

        // Move the other item back to this item's original slot
        otherItem.transform.SetParent(parentAfterDrag);
        otherItem.transform.localPosition = Vector3.zero;
    }

    // Move the item to the given slot.
    private void MoveItemToSlot(InventorySlot slot)
    {
        transform.SetParent(slot.transform);
        transform.localPosition = Vector3.zero;
    }

    // Move back to original slot if dropped in an invalid location.
    private void ReturnToOriginalSlot()
    {
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
    }
}
