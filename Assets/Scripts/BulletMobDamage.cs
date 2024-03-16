using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMobDamage : MonoBehaviour
{
    // reference to ranged mob
    [SerializeField] RangedMobController ranged;

    public int damage;

    private void Awake()
    {
        ranged = GetComponent<RangedMobController>();
    }

    private void Update()
    {
        if ( gameObject.activeSelf)
        {
            
        }
    }



}
