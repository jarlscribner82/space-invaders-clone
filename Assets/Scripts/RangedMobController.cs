using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMobController : MobController
{
    // firing state
    private bool isFiring = false;

    // range for firing cooldown
    [SerializeField] int cooldownMin;
    [SerializeField] int cooldownMax;

    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(FireInterval());
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    // fire in one second intervals
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

    IEnumerator FireInterval()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(ShieldCooldown());
            isFiring = !isFiring;
        }
    }

    // generate a random cooldown time for firing
    int ShieldCooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
    }
}
