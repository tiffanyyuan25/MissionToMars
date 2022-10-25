using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour, IInteractable
{
    public ResourceItemData ItemData;
    [SerializeField] private string _prompt;
    [SerializeField] private int _amountOfOre;
    [SerializeField] private int _maxYield;

    private AudioSource _audioSource;

    private int count = 1;

    public string InteractionPrompt => _prompt;
    public int AmountOfOre => _amountOfOre;

    public bool Interact(Interactor interactor)
    {
        var resource = interactor.ResourceHolder;
        if (!resource) return false;

        int amountToAdd = _maxYield / count;

        if (amountToAdd > _amountOfOre)
        {
            amountToAdd = _amountOfOre;
        }

        if (resource.ResourceSystem.AddToResources(ItemData, amountToAdd))
        {
            if (_audioSource == null)
            {
                Debug.LogError( "The AudioSource in the player NULL!");
            } else {
                _audioSource.Play();
            }
            
            _amountOfOre -= amountToAdd;
            count += 1;
        }

        return true;
    }

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
