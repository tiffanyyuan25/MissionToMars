using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IInteractable
{
    public ResourceItemData ItemData;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        if (!resource) return false;

        if (resource.ResourceSystem.AddToResources(ItemData, 1))
        {
            this.gameObject.SetActive(false);
        }

        return true;
    }
}
