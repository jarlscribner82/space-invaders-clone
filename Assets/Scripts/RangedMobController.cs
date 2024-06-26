using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE - child class
public class RangedMobController : MobController
{
    // object reference for projectile
    public GameObject projectilePrefab;

    protected override void Awake()
    {
        actionEnabled = true;

        base.Awake();        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base .Update();

        // ABSTRACTION
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
