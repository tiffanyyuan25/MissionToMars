using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IInteractable
{
    public ResourceItemData ItemData;
    [SerializeField] private string _prompt;
    private AudioSource _audioSource;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        if (!resource) return false;

        if (resource.ResourceSystem.AddToResources(ItemData, 1))
        {
            if (_audioSource == null)
            {
                Debug.LogError( "The AudioSource in the player NULL!");
            } else {
                _audioSource.Play();
            }
            
            this.gameObject.SetActive(false);
        }

        return true;
    }

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
