using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    // player attributes
    public int playerStr;
    public int playerSpd;
    public int playerHealth;
    public int playerPoints;
    public int playerMaxHealth;

    public bool isAlive = true;

    // boundary references
    private int boundaryRange = 12;

    // object reference for projectile
    public GameObject projectilePrefab;

    // spawn point for projectile
    public Transform projectileSpawnPoint;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FireProjectile();
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

        KeepInBounds();
    }

    // keep the player in bounds
    void KeepInBounds()
    {
        if (playerRb.transform.position.x <= -boundaryRange)
        {
            playerRb.transform.position = new Vector3(-boundaryRange, playerRb.transform.position.y, playerRb.transform.position.z);
        }
        if (playerRb.transform.position.x >= boundaryRange)
        {
            playerRb.transform.position = new Vector3(boundaryRange, playerRb.transform.position.y, playerRb.transform.position.z);
        }
    }

    // fire a projectile. creates an instance of an object, places it at the players position, points it in the direction of the copied object
    void FireProjectile()
    {
        bool fireInput = Input.GetButtonDown("Fire1");

        if (fireInput)
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
}
