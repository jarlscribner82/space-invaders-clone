using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE - parent class
public class BulletController : MonoBehaviour
{
    // bullet attribute
    public int speed;

    // bool for limiting amount of coroutines per life cycle to one
    public bool fired = false;

    protected virtual void Update()
    {
        // ABSTRACTION
        StartDeactivation();
    }

    // check if bullet is active and start to deactivate it
    void StartDeactivation()
    {
        if (gameObject.activeSelf && !fired)
        {
            fired = true;
            StartCoroutine(DeactivateBullet());
        }
    }

    // set bullet to deactivate after one second
    protected virtual IEnumerator DeactivateBullet()
    {
        yield return new WaitForSeconds(1);
        fired = false;
        gameObject.SetActive(false);

    }
}
