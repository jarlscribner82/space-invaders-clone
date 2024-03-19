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

    //private void OnTriggerEnter(Collider other)
    //{
    //    // damage the player on bullet contact and destroy bullet
    //    if (other.gameObject.CompareTag("Player") || gameObject.CompareTag("Player"))
    //    {
    //        other.gameObject.GetComponent<PlayerController>().playerHealth -= ranged.GetComponent<RangedMobController>().MobDamage;
    //        fired = false;
    //        gameObject.SetActive(false);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        // damage the player on bullet contact and destroy bullet
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().playerHealth -= ranged.GetComponent<RangedMobController>().MobDamage;
            fired = false;
            gameObject.SetActive(false);
        }
    }
}
