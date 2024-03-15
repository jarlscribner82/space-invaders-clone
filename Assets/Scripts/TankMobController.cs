using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMobController : MobController
{
    // shield reference
    [SerializeField] GameObject shield;

    // shield state
    [SerializeField] bool shieldActive = true;

    protected override void Start()
    {
        base.Start();

        StartCoroutine(ToggleShieldState());
    }

    protected override void Update()
    {
        base.Update();

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

    // raise health, stackable limited to m_MobHealth
    public virtual void RaiseHealth()
    {
        mobHealth += 1;

        if (mobHealth > MaxHealth)
        {
            mobHealth = MaxHealth;
        }
    }
}
