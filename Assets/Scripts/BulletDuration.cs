using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuration : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    private bool isfired = false;

>>>>>>> Stashed changes
    private void Update()
    {
        
        StartDeactivation();
    }

    // check if bullet is active and start to deactivate it
    void StartDeactivation()
    {
<<<<<<< Updated upstream
        if (gameObject.activeSelf)
        {
=======
        if (gameObject.activeSelf && !isfired)
        {
            isfired = true;
>>>>>>> Stashed changes
            StartCoroutine(DeactivateBullet());
        }
    }

    // set bullet to deactivate after one second
    IEnumerator DeactivateBullet()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
<<<<<<< Updated upstream
=======
        isfired= false;
>>>>>>> Stashed changes
    }
}
