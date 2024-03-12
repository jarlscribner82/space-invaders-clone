using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryMobController : MobController
{
    private Rigidbody infantryRb;
    
    [SerializeField] float original_Speed;
    public float speed;


    // boundary references
    private int boundaryRange = 12;

    void Start()
    {
        speed = original_Speed;

        infantryRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //FollowPlayer();
    }

    // enable enemy track and follow for player
    void FollowPlayer()
    {
        // get the vector that points in the players direction
        Vector3 getDirection = (playerController.transform.position - infantryRb.transform.position).normalized;

        // move the enemy towards the player
        infantryRb.AddForce(getDirection * speed, ForceMode.Impulse);

        // set a max speed
        if (infantryRb.velocity.magnitude > speed)
        {
            infantryRb.velocity = infantryRb.velocity.normalized * speed;
        }

        KeepInBounds();
    }

    void KeepInBounds()
    {
        if (infantryRb.transform.position.x <= -boundaryRange)
        {
            infantryRb.transform.position = new Vector3(-boundaryRange, infantryRb.transform.position.y, infantryRb.transform.position.z);
        }
        if (infantryRb.transform.position.x >= boundaryRange)
        {
            infantryRb.transform.position = new Vector3(boundaryRange, infantryRb.transform.position.y, infantryRb.transform.position.z);
        }
    }
}
