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

    public ResourceItemData AssignedResourceItem => assignedResourceItem;
    public ResourceAllocationMenu ParentDisplay { get; private set;}

    private void Awake ()
    {
        add?.onClick.AddListener(OnAddClick);
        subtract?.onClick.AddListener(OnSubtractClick);

        ParentDisplay = transform.parent.GetComponent<ResourceAllocationMenu>();
    }

    public void Init(ResourceItemData item, int num)
    {
        assignedResourceItem = item;
        UpdateUISlot(num);
    }
    
    private void OnAddClick()
    {
        Debug.Log("Add");
    }

    private void OnSubtractClick()
    {
        Debug.Log("Subtract");
    }

    public void UpdateUISlot (int num) 
    {
        itemCount.text = num.ToString();
    }
}
