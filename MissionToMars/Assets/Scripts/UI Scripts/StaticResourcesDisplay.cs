using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticResourcesDisplay : ResourcesDisplay
{
    [SerializeField] private ResourceHolder resourceHolder;
    [SerializeField] private ResourcesSlot_UI[] slots;

    public override void AssignSlot(ResourceSystem resToDisplay)
    {
        slotDictionary = new Dictionary<ResourcesSlot_UI, ResourceSlot>();

        if (slots.Length != resourceSystem.ResourceSize) Debug.Log($"Inventory slots out of sync on {this.gameObject}");

        for (int i = 0; i < resourceSystem.ResourceSize; i++)
        {
            slotDictionary.Add(slots[i], resourceSystem.ResourceSlots[i]);
            slots[i].Init(resourceSystem.ResourceSlots[i]);
        }
    }

    protected override void Start()
    {
        base.Start();

        if (resourceHolder != null)
        {
            resourceSystem = resourceHolder.ResourceSystem;
            resourceSystem.OnResourceSlotChanged += UpdateSlot;
        }
        else Debug.LogWarning($"No resources assigned to {this.gameObject}");

        AssignSlot(resourceSystem);
    }
}
