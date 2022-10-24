using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ResourceAllocationManager_UI : MonoBehaviour
{
    protected Dictionary<ResourceAllocator_UI, ResourceItemData> itemDictionary;

    public Dictionary<ResourceAllocator_UI, ResourceItemData> SlotDictionary => itemDictionary;

    protected void Start()
    {

    }

    protected void UpdateSlot(ResourceItemData newItem, int num)
    {
        foreach (var item in itemDictionary)
        {
            if (item.Value == newItem) // Item data
            {
                item.Key.UpdateUISlot(num); // UI class
            }
        }
    }

    public void SlotClicked(ResourcesSlot_UI clickedSlot)
    {
        Debug.Log("Slot clicked");
    }
}
