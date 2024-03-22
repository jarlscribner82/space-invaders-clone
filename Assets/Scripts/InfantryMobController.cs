using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InfantryMobController : MobController
{
    // player reference
    private PlayerController player;

    // movement reference
    private Movement mover;

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

        mover = GameObject.Find("Mover").GetComponent<Movement>();
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
            mover.MovetTo(player.playerRb, infantryRb, Speed);
        }
        else
        {
            mover.MoveTo(post, infantryRb, Speed);
            StartCoroutine(Cooldown());
        }
        mover.KeepInBounds(infantryRb, boundaryRange);
    }

    // assign a random defensive post for unit to flee to when defensive
    Transform AssignPost()
    {
        int postNumber = Random.Range(0, posts.Length);
        
        post = posts[postNumber];

        return post;
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        // change to defense mode when in range of the shielded player
        if (other.gameObject.CompareTag("Player") && player.isShielding)
        {
            offensive = false;
        }
    }
}
