using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatController : MonoBehaviour
{
    public GameObject sword; //Add more objects for each type of weapon as needed
    public bool canAttack = true;
    public float attackCoolDown = 1.0f; //1 second
    public AudioClip swordAttackSound;
    public bool isAttacking = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //Left click
        {
            //Should we decide to add more weapons to this list, need a way of determining which one is used.
            if(canAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();

        //This is the name of the animation set in the Unity animator.
        //If there isn't one yet, make one if the script is having issues.
        //Make sure the trigger name matches the script and vice versa.
        anim.SetTrigger("Attack");

        //Resets the attack based on the value given
        StartCoroutine(ResetAttackCooldown());

        //Plays an audio clip on attacking
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(swordAttackSound);

        //For weapon to do damage, add a collider to it. Make sure it's set to "Is Trigger"
        //and feel free to adjust the box for reach of the weapon.
        //Enemies should have a box collider component on them for hit box. They also will need a RigidBody component.
        //Enemies to be affected by weapons should have the "Enemy" tag set to them on Unity.
        //Additionally for the detected attack, the enemy will need an animation controller with a new Paramter Trigger called "Hit"

    }

    //Resets the attack cooldown
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }

    //Resets the bool for is attacking
    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f); //You want to change this time to match the length of the animation being used
        isAttacking = false;
    }
}
