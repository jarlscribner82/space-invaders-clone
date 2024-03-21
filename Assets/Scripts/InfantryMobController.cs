using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InfantryMobController : MobController
{
    // player reference
    private PlayerController player;

    // allow access to rigid body
    private Rigidbody infantryRb;

    // attack state
    [SerializeField] bool offensive = true;

    // post references
    [SerializeField] Transform[] posts;
    private Transform post;
    
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

        post = AssignPost();

        player = GameObject.Find("player").GetComponent<PlayerController>();
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        MoveWithAI();
    }

    // infantry movement with simple AI determining offensive or defensive movement
    void MoveWithAI()
    {
        if (offensive)
        {
            MovetTo(player.playerRb);
        }
        else
        {
            MovetTo(post);
            StartCoroutine(Cooldown());
        }
    }

    // enable enemy track and follow for player
    void MovetTo(Rigidbody target)
    { 
        // get the vector that points in the players direction
        Vector3 getDirection = (target.transform.position - infantryRb.transform.position).normalized;

        // move the enemy towards the player
        infantryRb.AddForce(getDirection * Speed, ForceMode.Impulse);

        // set a max speed
        if (infantryRb.velocity.magnitude > Speed)
        {
            infantryRb.velocity = infantryRb.velocity.normalized * Speed;
        }

        KeepInBounds();
    }

    // enable enemy to seek a specific location
    void MovetTo(Transform target)
    {
        // get the vector that points in the players direction
        Vector3 getDirection = (target.transform.position - infantryRb.transform.position).normalized;

        // move the enemy towards the player
        infantryRb.AddForce(getDirection * Speed, ForceMode.Impulse);

        // set a max speed
        if (infantryRb.velocity.magnitude > Speed)
        {
            infantryRb.velocity = infantryRb.velocity.normalized * Speed;
        }

        KeepInBounds();
    }

    // assign a random defensive post for unit to flee to when defensive
    Transform AssignPost()
    {
        int postNumber = Random.Range(0, posts.Length);
        
        post = posts[postNumber];

        return post;
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

    // action cooldown timer
    private IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(cooldownMax);
        offensive = true;
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
            DealDamage();
            SpawnManager.instance.enemyCount--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // change to defense mode when in range of the shielded player
        if (other.gameObject.CompareTag("Player") && player.isShielding)
        {
            offensive = false;
        }
    }
}
