using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
    public ResourceItemData ItemData;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        Debug.Log("Got the food" + resource);
        if (!resource) return false;

        if (resource.ResourceSystem.AddToResources(ItemData, 1))
        {
            Debug.Log("Attempting to destroy");
            Destroy(this.gameObject);
        }

        return true;
    }
}
