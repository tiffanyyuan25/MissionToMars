using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseResourceItem;

    protected ResourceSystem resourceSystem;
    protected Dictionary<ResourcesSlot_UI, ResourceSlot> slotDictionary;

    public ResourceSystem ResourceSystem => resourceSystem;
    public Dictionary<ResourcesSlot_UI, ResourceSlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(ResourceSystem resToDisplay);

    protected virtual void UpdateSlot(ResourceSlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot) // Slot class
            {
                slot.Key.UpdateUISlot(updatedSlot); // Slot UI
            }
        }
    }

    public void SlotClicked(ResourcesSlot_UI clickedSlot)
    {
        Debug.Log("Slot clicked");
    }
}
