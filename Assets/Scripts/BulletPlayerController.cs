using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : BulletController
{
    protected override void Update()
    {
        base.Update();
        MoveBullet();
    }

    // move object up
    private void MoveBullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
