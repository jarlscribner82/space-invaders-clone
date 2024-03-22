using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMobController : MobController
{
    // object reference for projectile
    public GameObject projectilePrefab;

    // Update is called once per frame
    protected override void Update()
    {
        base .Update();

        Fire();
    }

    // fire projectile from a pool when not firing
    void Fire()
    {
        // get an object from the pool
        GameObject pooledProjectile = BulletMobPooler.SharedInstance.GetPooledObject();

        // if pooled projectile is inactive
        if (pooledProjectile != null && !actionEnabled)
        {
            actionEnabled = true;

            // activate it
            pooledProjectile.SetActive(true);

            // set position and rotation
            pooledProjectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }

    // raise attack speed, limited to on shot persecond
    public virtual void RaiseFiringSpeed()
    {
        cooldownMax -= 1;

        if (cooldownMax <= cooldownMin) 
        {
            cooldownMax = cooldownMin + 1;
        }
    }
}
