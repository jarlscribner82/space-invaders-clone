using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuration : MonoBehaviour
{
    public bool fired = false;

    private void Update()
    {
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
    IEnumerator DeactivateBullet()
    {
        yield return new WaitForSeconds(1);
        fired = false;
        gameObject.SetActive(false);
        
    }
}
