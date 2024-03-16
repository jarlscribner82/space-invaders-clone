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
            other.gameObject.GetComponent<BulletMobController>().fired = false;
            other.gameObject.SetActive(false);
        }

        // destroy infantry unit on contact
        if (other.gameObject.CompareTag("Infantry"))
        {
            Destroy(other.gameObject);
        }
    }
}
