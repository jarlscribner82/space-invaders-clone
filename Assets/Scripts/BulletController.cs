using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // bullet attribute
    [SerializeField] int speed;
    [SerializeField] int damage;

    // bool for limiting amount of coroutines per life cycle to one
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
