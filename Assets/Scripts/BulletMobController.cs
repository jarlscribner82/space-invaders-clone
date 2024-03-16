using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMobController : BulletController
{
    // access ranged mob
    [SerializeField] GameObject ranged;

    protected override void Update()
    {
        base.Update();
        MoveBullet();
    }

    // move object down
    private void MoveBullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
    }

    private void OnTriggerEnter(Collider other)
    {
        // damage the player on bullet contact and destroy bullet
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().playerHealth -= ranged.GetComponent<RangedMobController>().MobDamage;
            fired = false;
            gameObject.SetActive(false);
        }
    }
}
