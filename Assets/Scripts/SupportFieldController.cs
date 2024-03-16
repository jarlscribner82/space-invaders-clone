using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SupportFieldController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // reference variables
        var supporter = gameObject.GetComponentInParent<SupportMobController>();
        var tank = other.gameObject.GetComponent<TankMobController>();
        var ranged = other.gameObject.GetComponent<RangedMobController>();
        var infantry = other.gameObject.GetComponent<InfantryMobController>();

        // check if a specific unit is supported by an active supporter, if not switch support state to true and buff it
        if (other.gameObject.CompareTag("Tank") && !tank.isSupported && supporter.isSupporting)
        {           
            tank.isSupported = true;
            tank.RaiseHealth();
        }
        if (other.gameObject.CompareTag("Ranged") && !ranged.isSupported && supporter.isSupporting)
        {                      
            ranged.isSupported = true;
            ranged.RaiseDamage();
        }
        if (other.gameObject.CompareTag("Infantry") && !infantry.isSupported && supporter.isSupporting)
        {
            infantry.isSupported = true;
            infantry.RaiseSpeed();
        }
    }    
}
