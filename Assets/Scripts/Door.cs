using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public string exitName;

    public int levelGenerate;

    //Change this so the player is sent to a new random room / animation transition
    //Look into implementing a way for the room to detect if all enemies have been defeated before moving on
    public bool Interact(Interactor interactor)
    {
        Debug.Log(message:"Opening Door");

        PlayerPrefs.SetString("LastExitName", exitName);

        levelGenerate = Random.Range(1,4);
        SceneManager.LoadScene(levelGenerate);

        return true;
    }
}
