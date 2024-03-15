using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuration : MonoBehaviour
{
    // firing state
    bool isFired = false;

    private void Update()
    {
        StartDeactivation();
    }

    // check if bullet is active and just starting to fire, then start to deactivate it
    void StartDeactivation()
    {
        if (gameObject.activeSelf && !isFired)
        {
            isFired = true;
            StartCoroutine(DeactivateBullet());
        }
    }

    // set bullet to deactivate after one second
    IEnumerator DeactivateBullet()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        isFired = false;
    }
}
