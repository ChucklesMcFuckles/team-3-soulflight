using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZone : MonoBehaviour
{
    // array of objects to spawn
    public GameObject[] spawnObjects;
    // the amount of objects to spawn
    public int spawnAmount;
    
    public float spawnRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    void spawn()
    {
        // get the center of the game object
        Vector3 center = transform.position;

        // spawn random objects spawnAmount times
        for (int i = 0; i < spawnAmount; i++)
        {
            // spawn position relative to the center of the game object
            Vector3 spawnPosition = new Vector3(Random.Range((-transform.localScale.x - spawnRadius), (transform.localScale.x+spawnRadius)), (0.25f+(i * 0.1f)), Random.Range((-transform.localScale.z-spawnRadius), (transform.localScale.z+spawnRadius)));
            
            // randomNum
            int randomNum = Random.Range(0, spawnObjects.Length);

            // spawn random object slightly with random rotation
            Instantiate(spawnObjects[randomNum], center + spawnPosition, Quaternion.identity);
        }
    }
}
