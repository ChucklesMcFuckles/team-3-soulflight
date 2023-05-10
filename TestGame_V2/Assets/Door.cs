using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    //Change this so the player is sent to a new random room / animation transition
    public bool Interact(Interactor interactor)
    {
        Debug.Log(message:"Opening Door");
        return true;
    }
}
