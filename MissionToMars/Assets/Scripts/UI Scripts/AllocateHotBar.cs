using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllocateHotBar : MonoBehaviour
{
    [SerializeField] private ResourcesSlot_UI[] UI_slots;

    private Dictionary<ResourceItemData, ResourcesSlot_UI> lookUpSlot;

    public void AssignSlots(Dictionary<ResourceItemData, int> slots)
    {
        lookUpSlot = new Dictionary<ResourceItemData, ResourcesSlot_UI>(5);
        int i = 0;
        foreach (var slot in slots)
        {
            var newSlot = new ResourceSlot(slot.Key, slot.Value);
            UI_slots[i].Init(newSlot);
            lookUpSlot[slot.Key] = UI_slots[i];
            i += 1;
        }
    }

    public void UpdateSlot(ResourceItemData item, int amountToUpdate)
    {
        lookUpSlot[item].UpdateUISlot(new ResourceSlot(item, amountToUpdate));
    }

}
