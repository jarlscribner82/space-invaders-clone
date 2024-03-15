using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletPlayer : MonoBehaviour
{
    // Speed fo object
    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // move object up
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
