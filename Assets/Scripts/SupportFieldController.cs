using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SupportFieldController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // reference variables
        var supporter = gameObject.GetComponentInParent<SupportMobController>();
        var tank = collision.gameObject.GetComponent<TankMobController>();
        var ranged = collision.gameObject.GetComponent<RangedMobController>();
        var infantry = collision.gameObject.GetComponent<InfantryMobController>();

        // check if a specific unit is supported by an active supporter, if not switch support state to true and buff it
        if (collision.gameObject.CompareTag("Tank") && !tank.isSupported && supporter.isSupporting)
        {           
            tank.isSupported = true;
            tank.RaiseHealth();

            Debug.Log("TANK: " + tank.mobHealth);
        }
        if (collision.gameObject.CompareTag("Ranged") && !ranged.isSupported && supporter.isSupporting)
        {                      
            ranged.isSupported = true;
            ranged.RaiseDamage();

            Debug.Log("RANGED: " + ranged.MobDamage);
        }
        if (collision.gameObject.CompareTag("Infantry") && !infantry.isSupported && supporter.isSupporting)
        {
            infantry.isSupported = true;
            infantry.RaiseSpeed();

            Debug.Log("INFANTRY: " + infantry.Speed);
        }
    }    
}
