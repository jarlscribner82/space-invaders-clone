using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMob : MonoBehaviour
{
    // destroy player projectiles on trigger
    private void OnTriggerEnter(Collider other)
    {
        // mob shield blocks player bullet
        if (other.gameObject.CompareTag("bullet-player"))
        {
            other.gameObject.GetComponent<BulletPlayerController>().fired = false;
            other.gameObject.SetActive(false);
        }
    }
}
