using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    private Transform player;

    private NavMeshAgent agent;

    public float enemyDistance = 0.7f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
    }

    //Call every frame
    void Update()
    {
        //Look at the player
        transform.LookAt(player);

        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.position) < enemyDistance)
        {
	    //Reaches the player
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
    }
}