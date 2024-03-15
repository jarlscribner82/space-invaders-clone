using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes
    [SerializeField] int m_MaxHealth;

    protected int MaxHealth
    {
        get { return m_MaxHealth; }
        set { m_MaxHealth = value; }
    }

    public int mobHealth;

    [SerializeField] int m_MobDamage;
    public virtual int MobDamage
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
            cooldownEnabled = true;
            StartCoroutine(SupporterCooldown());
        }
    }

    // deal damage to player
    public virtual void DealDamage()
    {
        playerController.playerHealth -= MobDamage;
    }

    // damage the mob
    public virtual void TakeDamage()
    {
        mobHealth -= playerController.playerStr;

        if (mobHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    // state toggler for recieving support
    protected virtual IEnumerator SupporterCooldown()
    {
            yield return new WaitForSecondsRealtime(cooldownMax);
            cooldownEnabled = false;
            isSupported = false;
    }

    // when colliding with a player bullet, take damage and deactivate the bullet
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player-bullet"))
        {
            TakeDamage();
            collision.gameObject.SetActive(false);
        }
    }
}
