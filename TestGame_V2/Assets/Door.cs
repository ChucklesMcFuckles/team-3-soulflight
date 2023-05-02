using UnityEngine;

public class Door : MonoBehaviour, ObjectInteractable
{
    private Animator _animator;
    private bool _isOpen;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _isOpen = true;
	    _animator.SetTrigger(name:"Open");
    }

    public bool CanInteract()
    {
	    return !_isOpen;
    }
}
