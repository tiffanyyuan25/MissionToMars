using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public ResourceItemData[] ItemsData;
    //public int[] ItemsAmount;    
    [SerializeField] private string _prompt;
    [SerializeField] private int[] ItemsAmount;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {        
        var resource = interactor.ResourceHolder;
        if (!resource) return false;
        int count = 0;                
        foreach (var item in ItemsData){            
            resource.ResourceSystem.AddToResources(item, ItemsAmount[count]);
            count++;
        }
        this.gameObject.SetActive(false);        

        return true;
    }
}
