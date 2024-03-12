using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMobController : MobController
{
    // shield reference
    [SerializeField] GameObject shield;

    // shield state
    [SerializeField] bool shieldActive = true;

    void Start()
    {
        StartCoroutine(ToggleShieldState());
    }

    private void Update()
    {
        ToggleShieldActive();
    }

    // turn shield object on or off depending on state
    void ToggleShieldActive()
    {
        if (shieldActive)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    // shield state togller
    IEnumerator ToggleShieldState()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(ShieldCooldown());
            shieldActive = !shieldActive;
        }
    }

    // generate a random cooldown time for shield
    int ShieldCooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
    }
}
