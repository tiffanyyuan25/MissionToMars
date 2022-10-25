using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ResourceAllocationManager_UI : MonoBehaviour
{
    public bool missionAllocator;
    public ResourceAllocator_UI[] allocators;
    protected Dictionary<ResourceAllocator_UI, ResourceItemData> itemDictionary  = new Dictionary<ResourceAllocator_UI, ResourceItemData>(5);

    public Dictionary<ResourceAllocator_UI, ResourceItemData> ItemDictionary => itemDictionary;

    protected void Start()
    {
    }

    public void AssignSlots(ResourceItemData[] items)
    {
        for (int i = 0; i < allocators.Length; i++)
        {
            itemDictionary[allocators[i]] = items[i];
        }
    }

    public void UpdateSlot(ResourceItemData newItem, int num)
    {
        foreach (var item in itemDictionary)
        {
            if (item.Value == newItem) // Item data
            {
                item.Key.UpdateUISlot(num); // UI class
            }
        }
    }

}
