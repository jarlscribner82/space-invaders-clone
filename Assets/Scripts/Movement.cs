using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Movement
{ 
    // enable rigid body to track and follow another rigid body
    public static void MovetTo(Rigidbody target, Rigidbody origin, float speed)
    {
        // get the vector that points in the targets direction
        Vector3 getDirection = (target.transform.position - origin.transform.position).normalized;

        // move the enemy towards the target
        origin.AddForce(getDirection * speed, ForceMode.Impulse);

        // set a max velocity
        if (origin.velocity.magnitude > speed)
        {
            origin.velocity = origin.velocity.normalized * speed;
        }
    }

    // enable rigid body to seek a specific transform
    public static void MoveTo(Transform target, Rigidbody origin, float speed)
    {
        // get the vector that points in the locations direction
        Vector3 getDirection = (target.transform.position - origin.transform.position).normalized;

        // move the enemy towards the location
        origin.AddForce(getDirection * speed, ForceMode.Impulse);

        // set a max speed
        if (origin.velocity.magnitude > speed)
        {
            origin.velocity = origin.velocity.normalized * speed;
        }
    }

    // enable rigid body to seek a specific location
    public static void MoveTo(float xPos, float yPos, float zPos, Rigidbody origin, float speed)
    {
        Vector3 target = new Vector3(xPos, yPos, zPos);

        // get the vector that points in the locations direction
        Vector3 getDirection = (target - origin.transform.position).normalized;

        // move the enemy towards the location
        origin.AddForce(getDirection * speed, ForceMode.Impulse);

        // set a max speed
        if (origin.velocity.magnitude > speed)
        {
            origin.velocity = origin.velocity.normalized * speed;
        }
    }

    // keep the rigid body in the confines of a specific x range
    public static void KeepInBounds(Rigidbody rb, float boundaryRange)
    {
        if (rb.transform.position.x <= -boundaryRange)
        {
            rb.transform.position = new Vector3(-boundaryRange, rb.transform.position.y, rb.transform.position.z);
        }
        if (rb.transform.position.x >= boundaryRange)
        {
            rb.transform.position = new Vector3(boundaryRange, rb.transform.position.y, rb.transform.position.z);
        }
    }

    // keep the rigid body in the confines of a specific x and y range
    public static void KeepInBounds(Rigidbody rb, float xBoundaryRange, float yBoundaryRange)
    {
        // x
        if (rb.transform.position.x <= -xBoundaryRange)
        {
            rb.transform.position = new Vector3(-xBoundaryRange, rb.transform.position.y, rb.transform.position.z);
        }
        if (rb.transform.position.x >= xBoundaryRange)
        {
            rb.transform.position = new Vector3(xBoundaryRange, rb.transform.position.y, rb.transform.position.z);
        }

        // y
        if (rb.transform.position.x <= -yBoundaryRange)
        {
            rb.transform.position = new Vector3(rb.transform.position.x, -xBoundaryRange, rb.transform.position.z);
        }
        if (rb.transform.position.x >= xBoundaryRange)
        {
            rb.transform.position = new Vector3(rb.transform.position.x, -yBoundaryRange, rb.transform.position.z);
        }
    }
}
