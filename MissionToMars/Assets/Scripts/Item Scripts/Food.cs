using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
    public ResourceItemData ItemData;
    [SerializeField] private string _prompt;
    [SerializeField] private AudioClip _audioClip;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        if (!resource) return false;

        if (resource.ResourceSystem.AddToResources(ItemData, 1))
        {
            if (_audioClip == null)
            {
                Debug.LogError( "The AudioSource in the player NULL!");
            } else {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position);
            }

            Destroy(this.gameObject);
        }

        return true;
    }
}
