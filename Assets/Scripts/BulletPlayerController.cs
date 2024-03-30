using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE - child class
public class BulletPlayerController : BulletController
{   
    void FixedUpdate()
    {
        // ABSTRACTION
        MoveBullet();
    }

    // move object up
    private void MoveBullet()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
