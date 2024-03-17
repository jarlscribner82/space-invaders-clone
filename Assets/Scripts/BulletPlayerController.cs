using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : BulletController
{   
    void FixedUpdate()
    {
        MoveBullet();
    }

    // move object up
    private void MoveBullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
