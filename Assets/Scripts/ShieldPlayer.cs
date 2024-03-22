using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    // destroy player projectiles on trigger
    private void OnTriggerEnter(Collider other)
    {
        // player shield blocks mob bullet
        if (other.gameObject.CompareTag("bullet-mob"))
        {
            other.gameObject.GetComponent<BulletMobController>().fired = false;
            other.gameObject.SetActive(false);
        }

        // player shield block infantry
        if (other.gameObject.CompareTag("Infantry"))
        {
            Destroy(other.gameObject);
            SpawnManager.Instance.enemyCount--;
        }
    }
}
