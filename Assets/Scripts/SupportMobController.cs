using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportMobController : MobController
{
    // support state
    public bool isSupporting = false;

    // movement variables
    [SerializeField] float speed = 0.1f;

    private bool movingLeft = true;
    private bool movingRight = false;

    // boundary variables
    private float leftBounds;
    private float rightBounds;

    protected override void Awake()
    {
        base.Awake();

        SetBounds();
    }

    protected override void Start()
    {
        base.Start();

        StartCoroutine(ToggleSupportState());
    }

    protected override void Update()
    {
        base.Update();

        Move();
    }

    // set movement boundaries according to prefab spawn position
    void SetBounds()
    {
        leftBounds = transform.position.x - 0.5f;
        rightBounds = transform.position.x + 0.5f;
    }

    // change direction when boundaries are breached
    void KeepInBounds()
    {
        if (transform.position.x < leftBounds)
        {
            movingLeft = false;
            movingRight = true;
        }
        if (transform.position.x > rightBounds)
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
            transform.position -= new Vector3(speed, 0, 0);
        }
        if (movingRight)
        {
            transform.position += new Vector3(speed, 0, 0);
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

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
