using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // inspector reference
    public PlayerController playerController;

    // mob attributes
<<<<<<< Updated upstream
    [SerializeField] int m_MobHealth;
    public int MobHealth 
    { 
        get { return m_MobHealth; }
        set
        {
            if (value > m_MobHealth)
            {
                m_MobHealth = value;
            }
        }
    }
=======
    [SerializeField] int m_MaxMobHealth;
    public int MaxMobHealth 
    { 
        get { return m_MaxMobHealth; }
        set { m_MaxMobHealth = value; }
    }

    public int mobHealth;
>>>>>>> Stashed changes
    
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
<<<<<<< Updated upstream

=======
        mobHealth = MaxMobHealth;
>>>>>>> Stashed changes
    }

    protected virtual void FixedUpdate()
    {
        if (isSupported && !cooldownEnabled)
        {
            Debug.Log("Support Cooldown Started");
            cooldownEnabled = true;
            StartCoroutine(SupporterCooldown());
        }
    }

    // raise damage, stackable with no limit
    public virtual void RaiseDamage()
    {
        MobDamage += 1;
    }

    // raise health, stackable limited to m_MobHealth
    public virtual void RaiseHealth()
    {
        MobHealth += 1;
    }

    // deal damage to player
    public virtual void DealDamage()
    {
        playerController.playerHealth -= MobDamage;
    }

<<<<<<< Updated upstream
=======
    protected virtual void TakeDamage()
    {
        mobHealth -= playerController.playerStr;
    }

>>>>>>> Stashed changes
    // state toggler for recieving support
    public virtual IEnumerator SupporterCooldown()
    {
            yield return new WaitForSecondsRealtime(cooldownMax);
            cooldownEnabled = false;
            isSupported = false;

<<<<<<< Updated upstream
        Debug.Log("Support Cooldown Finished");
=======
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet-player"))
        {
            TakeDamage();
            collision.gameObject.SetActive(false);
        }
>>>>>>> Stashed changes
    }
}
