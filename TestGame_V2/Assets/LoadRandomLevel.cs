using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRandomLevel : MonoBehaviour
{


    /* Could possibly setup some code that will fully reset a scene to be something new on enter,
    or make up for this by having multiple different rooms that can only ever be loaded once. Have a
    loop or if statement block that can adjust the number of loaded rooms, or remove them from the list?*/   
    public int levelGenerate;

    public void LoadTheLevel()
    {
        //Make this the number of scenes you want to load + 1 (Cause it will never touch the max)
        levelGenerate = Random.Range(1,4);
        SceneManager.LoadScene(levelGenerate);
    }
}
