using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMobController : BulletController
{
    // access ranged mob
    [SerializeField] GameObject ranged;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
    MoveBullet();
    }

    // move object down and ensure a constant velocity    
    private void MoveBullet()
    {
        rb.AddForce(Vector3.down * speed);
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
