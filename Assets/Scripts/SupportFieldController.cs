using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportFieldController : MonoBehaviour
{
    // reference variables, need t assign in inspector
    [SerializeField] SupportMobController supporter;
    [SerializeField] TankMobController tank;
    [SerializeField] RangedMobController ranged;
    [SerializeField] InfantryMobController infantry;

    private void Update()
    {
        UnsupportAll();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            SupportTank();
        }
        if (collision.gameObject.CompareTag("Ranged"))
        {
            SupportRanged();
        }
        if (collision.gameObject.CompareTag("Infantry"))
        {
            SupportInfantry();
        }
    }

    // heal a tank for one point of health, no overheal
    void SupportTank()
    {
        if (!tank.isSupported && supporter.isSupporting)
        {
            tank.isSupported = true;
            tank.mobHealth += 1;
            if (tank.mobHealth > tank.mobMaxHealth)
            {
                tank.mobHealth = tank.mobMaxHealth;
            }

            Debug.Log("Tank Health: " + tank.mobHealth);
        }
    }

    // raise ranged damage by one, stackable
    void SupportRanged()
    {
        if (!ranged.isSupported && supporter.isSupporting)
        {
            ranged.isSupported = true;
            ranged.mobDamage += 1;

            Debug.Log("Ranged Damage: " + ranged.mobDamage);
        }
    }

    // increase infantry move speed by .1, stackable
    void SupportInfantry()
    {
        if (!infantry.isSupported && supporter.isSupporting)
        {
            infantry.isSupported = true;
            infantry.speed += 0.1f;

            Debug.Log("Infantry Speed: " + infantry.speed);
        }
    }

    // when supporter is not supporting return all units to unsupported for next round of buffs
    void UnsupportAll()
    {
        if (!supporter.isSupporting)
        {
            tank.isSupported = false;

            ranged.isSupported = false;

            infantry.isSupported = false;
        }
    }
}
