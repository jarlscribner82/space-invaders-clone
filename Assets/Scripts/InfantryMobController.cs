using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryMobController : MobController
{
    // allow access to rigid body
    private Rigidbody infantryRb;
    
    // attributes unique to an infantry mob
    [SerializeField] float m_Speed;
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }

    // boundary references
    private int boundaryRange = 9;

    protected override void Awake()
    {
        base.Awake();

        // allow access to rigid body
        infantryRb = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        FollowPlayer();
    }

    // enable enemy track and follow for player
    void FollowPlayer()
    {
        // get the vector that points in the players direction
        Vector3 getDirection = (playerController.playerRb.transform.position - infantryRb.transform.position).normalized;

        // move the enemy towards the player
        infantryRb.AddForce(getDirection * Speed, ForceMode.Impulse);

        // set a max speed
        if (infantryRb.velocity.magnitude > Speed)
        {
            infantryRb.velocity = infantryRb.velocity.normalized * Speed;
        }

        KeepInBounds();
    }

    // keep the mpob in the game field
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

    // raise speed
    public void RaiseSpeed()
    {
        Speed += 0.1f;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        // destroy infantry instance on player contact, unawared
        if (collision.gameObject.CompareTag("Player") )
        {
            playerController.playerHealth -= MobDamage;
            SpawnManager.instance.enemyCount--;
            Destroy(gameObject);
        }
        
        //  destroy infantry instance on player shield contact, rewarded
        if (collision.gameObject.CompareTag("player shield"))
        {
            playerController.playerHealth -= MobDamage;
            SpawnManager.instance.enemyCount -- ;
            Destroy(gameObject);
        }
    }
}
