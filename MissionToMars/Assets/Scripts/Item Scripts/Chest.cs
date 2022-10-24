using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public ResourceItemData[] ItemDatas;
    [SerializeField] private string _prompt;
    [SerializeField] private int [] _amount;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        if (!resource) return false;
        int i = 0;

        foreach (var item in ItemDatas)
        {
            resource.ResourceSystem.AddToResources(item, _amount[i]);
            i += 1;
        }

        this.gameObject.SetActive(false);

        return true;
    }
}
