using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SupportMobController : MobController
{
    // movement reference
    //private Movement mover;

    // allow access to rigid body
    private Rigidbody supporterRb;

    // support state
    public bool isSupporting = false;

    // movement variables
    [SerializeField] float speed = 0.1f;

    private bool movingLeft = true;
    private bool movingRight = false;

    // boundary variables
    [SerializeField] float moveRange = 0.75f;
    private float leftBounds;
    private float rightBounds;

    protected override void Awake()
    {
        base.Awake();

        supporterRb = GetComponent<Rigidbody>();
        //mover = GameObject.Find("Mover").GetComponent<Movement>();

        SetBounds();
    }

    protected override void Start()
    {
        base.Start();

        StartCoroutine(ToggleSupportState());
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    // set movement boundaries according to prefab spawn position
    void SetBounds()
    {
        leftBounds = supporterRb.transform.position.x - moveRange;
        rightBounds = supporterRb.transform.position.x + moveRange;
    }

    // change direction when boundaries are breached
    void KeepInBounds()
    {
        if (supporterRb.transform.position.x <= leftBounds)
        {
            movingLeft = false;
            movingRight = true;
        }
        if (supporterRb.transform.position.x >= rightBounds)
        { 
            movingRight = false;
            movingLeft = true;
        }
    }

    // move the prefab left or right depending on current direction traveled
    void Move()
    {
        if (movingLeft)
        {
            Movement.MoveTo(leftBounds, supporterRb.transform.position.y, supporterRb.transform.position.z, supporterRb, speed);
        }
        if (movingRight)
        {
            Movement.MoveTo(rightBounds, supporterRb.transform.position.y, supporterRb.transform.position.z, supporterRb, speed);
        }
        KeepInBounds();
    }

    // support state toggler
    IEnumerator ToggleSupportState()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(SupportCooldown());
            isSupporting = !isSupporting;
        }
    }

    // generate a random cooldown time for shield
    int SupportCooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
    }
}
