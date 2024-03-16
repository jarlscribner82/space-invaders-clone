using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMobController : BulletController
{
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
}
