using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    // access rigid body
    public Rigidbody playerRb;

    // Movement reference
    private Movement mover;

    // player attributes
    public int playerStr;
    public int playerSpd;
    public int playerHealth;
    public int playerPoints;
    public int playerMaxHealth;

    public bool isAlive = true;

    // boundary references
    private int boundaryRange = 9;

    // object reference for shield
    public GameObject shield;

    public bool isShielding = false;

    // object reference for projectile
    public GameObject projectilePrefab;

    // spawn point for projectile
    public Transform projectileSpawnPoint;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        mover = GameObject.Find("Mover").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FireProjectile();
        ActivateShield();
    }

    // enable horizontal motion and max speed
    void PlayerMove()
    {
        // initialize player inputs
        float horMove = Input.GetAxis("Horizontal");

        // enable horizontal motion with left stick
        if (horMove > 0)
        {
            playerRb.AddForce(Vector3.right * playerSpd * horMove, ForceMode.VelocityChange);
        }
        else if (horMove < 0)
        {
            playerRb.AddForce(Vector3.left * playerSpd * -horMove, ForceMode.VelocityChange);
        }
        else if (horMove == 0)
        {
            playerRb.velocity = Vector3.zero;
        }
        // set a max speed
        if (playerRb.velocity.magnitude > playerSpd)
        {
            playerRb.velocity = playerRb.velocity.normalized * playerSpd;
        }

        mover.KeepInBounds(playerRb, boundaryRange);
    }

    //// keep the player in bounds
    //void KeepInBounds()
    //{
    //    if (playerRb.transform.position.x <= -boundaryRange)
    //    {
    //        playerRb.transform.position = new Vector3(-boundaryRange, playerRb.transform.position.y, playerRb.transform.position.z);
    //    }
    //    if (playerRb.transform.position.x >= boundaryRange)
    //    {
    //        playerRb.transform.position = new Vector3(boundaryRange, playerRb.transform.position.y, playerRb.transform.position.z);
    //    }
    //}

    // fire a projectile. creates an instance of an object, places it at the players position, points it in the direction of the copied object
    // firing prohibited if shield is active
    void FireProjectile()
    {
        bool fireInput = Input.GetButtonDown("Fire1");

        if (fireInput && !isShielding)
        {
            // get an object from the pool
            GameObject pooledProjectile = BulletPlayerPooler.SharedInstance.GetPooledObject();

            // if pooled projectile is inactive
            if (pooledProjectile != null)
            {
                // activate it
                pooledProjectile.SetActive(true);

                // set position and rotation
                pooledProjectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
            }
        }
    }

    // activate or deactivate shield when x button held, also changes shielding state
    void ActivateShield()
    {
        bool activateShield = Input.GetButton("Fire2");

        if (activateShield)
        {
            isShielding = true;
            shield.SetActive(true);
        }
        else
        {
            isShielding = false;
            shield.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet-mob") && isShielding)
        {
            collision.gameObject.GetComponent<BulletMobController>().fired = false;
            collision.gameObject.SetActive(false);
        }
    }
}
