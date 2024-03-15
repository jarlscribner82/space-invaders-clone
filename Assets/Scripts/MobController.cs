using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes
    [SerializeField] int m_MaxHealth;
    public int MaxHealth 
    { 
        get { return m_MaxHealth; }
        set { m_MaxHealth = value; }
    }

    public int mobHealth;
    
    [SerializeField] int m_MobDamage;
    public int MobDamage
    {
        get { return m_MobDamage; }
        set { m_MobDamage = value; }
    }

    // range for cooldown
    public int cooldownMin;
    public int cooldownMax;

    // support state
    public bool cooldownEnabled = false;
    public bool isSupported = false;

    protected virtual void Awake()
    {
        // allow access to player
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }
    protected virtual void Start()
    {
        mobHealth = MaxHealth;
    }

    protected virtual void Update()
    {
        if (isSupported && !cooldownEnabled)
        {
            Debug.Log("Support Cooldown Started");
            cooldownEnabled = true;
            StartCoroutine(SupporterCooldown());
        }
    }

    // deal damage to player
    public virtual void DealDamage()
    {
        playerController.playerHealth -= MobDamage;
    }

    // state toggler for recieving support
    public virtual IEnumerator SupporterCooldown()
    {
            yield return new WaitForSecondsRealtime(cooldownMax);
            cooldownEnabled = false;
            isSupported = false;

        Debug.Log("Support Cooldown Finished");
    }
}
