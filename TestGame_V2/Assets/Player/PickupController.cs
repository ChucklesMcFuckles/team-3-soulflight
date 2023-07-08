using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponContainer, fpsCam;

    public float pickupRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    /*All weapons that have this script on them should contain RigidBody components on the object
    The settings for RigidBody: Interpolate must be set to Extrapolate, and Collision Detection must be set to Continuous Speculative*/
    private void Start()
    {
        if(!equipped)
        {
            //disable weapon scripts: weaponScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;

        }

        if(equipped)
        {
            //enable weapon scripts: weaponScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull) 
            PickUp();
        
        if(equipped && Input.GetKeyDown(KeyCode.Q))
            Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make a weapon the child of the camera and move it to the default position
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Create rigidbody kinematic and boxcollider trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable the script for what ever weapon you're using
        //somethingScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Make the parent null
        transform.SetParent(null);

        //Remove rigidbody kinematic and boxcollider trigger
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Drop gun with physics using player's velocity
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //Add force
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable the script for what ever weapon you're using
        //somethingScript.enabled = false;
    }
}
