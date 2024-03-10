using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private PlayerController playerController;
    public int mobHealth;
    public int mobMaxHealth;
    [SerializeField] int mobDamage;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();

        mobHealth = mobMaxHealth;
    }

    public virtual void DealDamage()
    {
        playerController.playerHealth -= mobDamage;
    }
}
