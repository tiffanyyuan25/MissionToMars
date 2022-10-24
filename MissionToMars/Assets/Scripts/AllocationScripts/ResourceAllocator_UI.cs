using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class ResourceAllocator_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private ResourceItemData assignedResourceItem;
    [SerializeField] private Button add;
    [SerializeField] private Button subtract;

    public ResourceAllocationMenu_UI GrandparentDisplay { get; private set;}

    public ResourceItemData AssignedResourceItem => assignedResourceItem;

    private void Awake ()
    {
        add?.onClick.AddListener(OnAddClick);
        subtract?.onClick.AddListener(OnSubtractClick);

        GrandparentDisplay = transform.parent.parent.GetComponent<ResourceAllocationMenu_UI>();
    }

    public void Init(ResourceItemData item, int num)
    {
        assignedResourceItem = item;
        UpdateUISlot(num);
    }
    
    private void OnAddClick()
    {
        var num = Int16.Parse(itemCount.text);
        if (GrandparentDisplay.UpdateGlobalAvailable(assignedResourceItem, 1))
        {
            itemCount.text = (num + 1).ToString();
        }
        
    }

    private void OnSubtractClick()
    {
        int num = Int16.Parse(itemCount.text);

        if (num > 0)
        {
            if (GrandparentDisplay.UpdateGlobalAvailable(assignedResourceItem, -1))
            {
                itemCount.text = (num - 1).ToString();
            }
        }
    }

    public void UpdateUISlot (int num) 
    {
        itemCount.text = num.ToString();
    }
}
