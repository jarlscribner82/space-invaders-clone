using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // mob shield blocks player bullet
        if (other.gameObject.CompareTag("player projectile"))
        {
            other.gameObject.GetComponent<BulletDuration>().fired = false;
            other.gameObject.SetActive(false);
        }
    }
}
