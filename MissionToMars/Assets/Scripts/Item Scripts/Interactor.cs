using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private ResourceHolder resourceHolder;
    public ResourceHolder ResourceHolder => resourceHolder;

    private readonly Collider[] _colliders = new Collider[3];

    [SerializeField] private int _numFound;

    // Update is called once per frame
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, 
        _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            var _interactable = _colliders[0].GetComponent<IInteractable>();
            Debug.Log("It's found some stuff and its trying its best");

            if (_interactable != null && Keyboard.current.iKey.wasPressedThisFrame)
            {
                Debug.Log("It's trying to interact");
                resourceHolder = GetComponent<ResourceHolder>();
                _interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

}
