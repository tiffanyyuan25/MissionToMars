using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResourcesSlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private ResourceSlot assignedResourceSlot;

    private Button button;

    public ResourceSlot AssignedResourceSlot => assignedResourceSlot;
    public ResourcesDisplay ParentDisplay { get; private set;}

    private void Awake ()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<ResourcesDisplay>();
    }

    public void Init(ResourceSlot slot)
    {
        assignedResourceSlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(ResourceSlot slot)
    {
        if(slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;

            if (slot.NumItems != 1) itemCount.text = slot.NumItems.ToString();
            else itemCount.text = "";
        }
        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if (assignedResourceSlot != null) UpdateUISlot(assignedResourceSlot);
    }

    public void ClearSlot()
    {
        assignedResourceSlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }
    private void OnUISlotClick()
    {
        ParentDisplay?.SlotClicked(this);
    }
}
