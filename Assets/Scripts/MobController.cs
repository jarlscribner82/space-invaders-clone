using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes

    protected bool dead = false;

    // ENCAPSULATION - allows modifaction while preserving original value

    // max health protected with backing field for easy initialization
    [SerializeField] int m_MaxHealth;
    public int MaxHealth 
    { 
        get { return m_MaxHealth; }
        set { m_MaxHealth = value; }
    }

    // mob health place holder
    public int mobHealth;

    // ENCAPSULATION - allows modifaction while preserving original value

    // damage protected with a backing field for easy initialization
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
    public bool supportCooldownEnabled = false;
    public bool isSupported = false;

    // action state
    protected bool actionEnabled = false;

    protected virtual void Awake()
    {
        // allow access to player
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }
    protected virtual void Start()
    {
        dead = false;
        mobHealth = MaxHealth;
        StartCoroutine(ActionInterval());
    }

    protected virtual void Update()
    {
        // ABSTRACTION
        SupportEnabler();
    }

    // enables mob to recieve support buffs once per trigger and starts a cooldown before allowing another buff to be recieved
    protected virtual void SupportEnabler()
    {
        if (isSupported && !supportCooldownEnabled && !SpawnManager.Instance.gameOver)
        {
            supportCooldownEnabled = true;
            StartCoroutine(SupporterCooldown());
        }
    }

    // action state toggler
    protected virtual IEnumerator ActionInterval()
    {
        while (true && !SpawnManager.Instance.gameOver)
        {
            yield return new WaitForSeconds(ActionCooldown());
            actionEnabled = !actionEnabled;
        }
    }

    // ensure random cooldown period each call
    protected virtual int ActionCooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
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
            supportCooldownEnabled = false;
            isSupported = false;
    }


    // mob takes damage equal to player strength, destroys mob if less than 1 health
    protected virtual void TakeDamage()
    {
        mobHealth -= playerController.playerStr;

        if (mobHealth <= 0)
        {
            Destroy(gameObject);
            SpawnManager.DecerimentEnemyCount();
            dead = true;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        // if bullet hits mob, set bullet to false to repool and reet duration bool, finally damage the monster
        if (collision.gameObject.CompareTag("bullet-player") && !dead)
        {            
            collision.gameObject.GetComponent<BulletPlayerController>().fired = false;
            collision.gameObject.SetActive(false);
            TakeDamage();
        }

        //  deal damage to playerdestroy infantry instance on contact, unawarded
        if (collision.gameObject.CompareTag("Player") && !dead && !playerController.isShielding)
        {
            DealDamage();
            Destroy(gameObject);
            SpawnManager.DecerimentEnemyCount();
            dead = true;
        } 
        
        // destroy mob on contact with player if it is shielding
        if (collision.gameObject.CompareTag("Player") && !dead && playerController.isShielding)
        {
            Destroy(gameObject);
            SpawnManager.DecerimentEnemyCount();
            dead = true;
        }
    }
        
}
