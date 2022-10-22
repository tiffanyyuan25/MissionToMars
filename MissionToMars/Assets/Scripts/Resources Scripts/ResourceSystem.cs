using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class ResourceSystem 
{
    [SerializeField] private List<ResourceSlot> resourceSlots;

    public List<ResourceSlot> ResourceSlots => resourceSlots;
    public int ResourceSize => ResourceSlots.Count;

    public UnityAction<ResourceSlot> OnResourceSlotChanged;

    public ResourceSystem(int size)
    {
        resourceSlots = new List<ResourceSlot>(size);

        for (int i = 0; i < size; i++)
        {
            resourceSlots.Add(new ResourceSlot());
        }
    }

    public bool AddToResources(ResourceItemData itemToAdd, int amountToAdd)
    {
        resourceSlots[0] = new ResourceSlot(itemToAdd, amountToAdd);
        return true;
    }
}
