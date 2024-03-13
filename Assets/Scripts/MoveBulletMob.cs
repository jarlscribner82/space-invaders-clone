using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletMob : MonoBehaviour
{
    // Speed of object
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        // move object down
        transform.Translate(speed * Time.deltaTime * Vector3.down);
    }
}
