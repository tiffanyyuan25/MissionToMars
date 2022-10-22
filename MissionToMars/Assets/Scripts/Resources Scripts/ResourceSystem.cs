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
        if (ContainsItem(itemToAdd, out ResourceSlot resSlot))
        {
            resSlot.AddToStack(amountToAdd);
            OnResourceSlotChanged?.Invoke(resSlot);
            return true;
        }
        
        if (HasFreeSlot(out ResourceSlot freeSlot))
        {
            freeSlot.UpdateResourceSlot(itemToAdd, amountToAdd);
            OnResourceSlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainsItem(ResourceItemData itemToAdd, out ResourceSlot resSlot)
    {
        var resSlots = ResourceSlots.Where(i => i.ItemData == itemToAdd).ToList();
        
        if (resSlots.Count >= 1)
        {
            resSlot = resSlots[0];
            return true;
        }

        resSlot = null;
        return false;
    }

    public bool HasFreeSlot(out ResourceSlot freeSlot)
    {
        freeSlot = ResourceSlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
