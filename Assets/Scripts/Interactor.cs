using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactor : MonoBehaviour
{
    //Serialized fields: Lets you edit them in the Inspector Menu
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            //if interactable is not null and the user presses the e key, interact
            if(interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
