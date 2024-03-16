using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes

    // max health protected with backing field for easy initialization
    [SerializeField] int m_MaxHealth;
    public int MaxHealth 
    { 
        get { return m_MaxHealth; }
        set { m_MaxHealth = value; }
    }

    // mob health place holder
    public int mobHealth;
    
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

    // mob takes damage equalt to player strength destroys mob if less than 1 health
    protected virtual void TakeDamage()
    {
        mobHealth -= playerController.playerStr;

        if (mobHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    // state toggler for recieving support
    public virtual IEnumerator SupporterCooldown()
    {
            yield return new WaitForSecondsRealtime(cooldownMax);
            cooldownEnabled = false;
            isSupported = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if bullet hits mob, set bullet to false to repool and reet duration bool, finally damage the monster
        if (collision.gameObject.CompareTag("bullet-player"))
        {
            collision.gameObject.GetComponent<BulletPlayerController>().fired = false;
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }
}
