using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetection : MonoBehaviour
{
    //This will go onto the weapon object
    //wc will be the object that holds the weapon, and the particle is what ever particle effect you want
    //The particles that spawn never go away in the hierarchy, so maybe delete them after a short period of coming out?
    public WeaponStatController wp;
    public GameObject hitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wp.isAttacking)
        {
            Debug.Log(other.name);
            //Plays the Hit trigger for animations on enemies
            other.GetComponent<Animator>().SetTrigger("Hit");

            Instantiate(hitParticle, new Vector3(other.transform.position.x,
                transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}
