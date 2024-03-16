using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    // destroy player projectiles on trigger
    private void OnTriggerEnter(Collider other)
    {
        // mob shield blocks player bullet
        if (other.gameObject.CompareTag("bullet-mob"))
        {
            other.gameObject.GetComponent<BulletDuration>().fired = false;
            other.gameObject.SetActive(false);
        }
    }
}
