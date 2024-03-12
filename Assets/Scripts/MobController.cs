using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes
    public int mobHealth;
    public int mobMaxHealth;

    [SerializeField] int mobOriginalDamage;
    public int mobDamage;

    // range for cooldown
    public int cooldownMin;
    public int cooldownMax;

    // support state
    public bool isSupported = false;

    void Start()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();

        mobDamage = mobOriginalDamage;

        mobHealth = mobMaxHealth;
    }

    public virtual void DealDamage()
    {
        playerController.playerHealth -= mobDamage;
    }
}
