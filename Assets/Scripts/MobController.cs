using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes
    public int mobHealth;
    [SerializeField] int mobMaxHealth;
    [SerializeField] int mobDamage;

    protected virtual void Awake()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();

        mobHealth = mobMaxHealth;
    }

    public virtual void DealDamage()
    {
        playerController.playerHealth -= mobDamage;
    }
}
