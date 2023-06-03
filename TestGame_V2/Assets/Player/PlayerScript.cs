using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    
    //Add a line that checks to see if the player object has a child object which matches one of the weapon names.
    //If DontDestroyOnLoad has an object disconnected from the player, it should remove it.
    void Start()
    {

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        Debug.Log(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
