using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : BulletController
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MoveBullet();
    }

    // move object up
    private void MoveBullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
