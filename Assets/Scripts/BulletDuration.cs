using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuration : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(DeactivateBullet());
    }

    // set bullet to deactivate after one second
    IEnumerator DeactivateBullet()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
