using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMobController : MobController
{
    // firing state
    private bool isFiring = true;

    protected override void Start()
    {
        base.Start();

        StartCoroutine(FireInterval());
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base .FixedUpdate();

        Fire();
    }

    // fire projectile from a pool when not firing
    void Fire()
    {
        // get an object from the pool
        GameObject pooledProjectile = BulletMobPooler.SharedInstance.GetPooledObject();

        // if pooled projectile is inactive
        if (pooledProjectile != null && !isFiring)
        {
            isFiring = true;

            // activate it
            pooledProjectile.SetActive(true);

            // set position and rotation
            pooledProjectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }

    // firing state toggler
    IEnumerator FireInterval()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Cooldown());
            isFiring = !isFiring;
        }
    }

    // generate a random cooldown time for firing
    int Cooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
    }
<<<<<<< Updated upstream
=======

    // raise damage, stackable with no limit
    public virtual void RaiseDamage()
    {
        MobDamage += 1;
    }
>>>>>>> Stashed changes
}