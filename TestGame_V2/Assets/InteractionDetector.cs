using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{

    private List<ObjectInteractable> _interactablesInRange = new List<ObjectInteractable>();

    void Update()
    {
        if (Input.GetButtonDown("Interact") && _interactablesInRange.Count > 0)
		{
			var interactable = _interactablesInRange[0];
			interactable.Interact();
			if(!interactable.CanInteract())
			{
				_interactablesInRange.Remove(interactable);
			}
		}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		var interactable = other.GetComponent<ObjectInteractable>();
		if(interactable != null && interactable.CanInteract())
		{
			_interactablesInRange.Add(interactable);
		}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
		var interactable = other.GetComponent<ObjectInteractable>();
		if(_interactablesInRange.Contains(interactable))
		{
			_interactablesInRange.Remove(interactable);
		}
    }
}
