using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    // enable horizontal motion and constant speed
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
}
