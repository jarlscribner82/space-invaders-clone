using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMobController : MobController
{
    // shield reference
    [SerializeField] GameObject shield;

    // shield state
    [SerializeField] bool shieldActive = true;

    // allow access to spawn manager
    private SpawnManager spawnManager;

    // reference to summonable mob
    [SerializeField] GameObject mobSummon;

    // spawner state
    [SerializeField] bool isSpawning = false;

    // spawner offset
    [SerializeField] float spawnOffset = 1.0f;

    protected override void Awake()
    {
        base.Awake();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    protected override void Start()
    {
        base.Start();

        StartCoroutine(ToggleShieldState());
        StartCoroutine(ToggleSpawnState());
    }

    protected override void Update()
    {
        base.Update();

        ToggleShieldActive();
        SummonInfantry();
    }

    // turn shield object on or off depending on state
    void ToggleShieldActive()
    {
        if (shieldActive)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    // shield state togller
    IEnumerator ToggleShieldState()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(ShieldCooldown());
            shieldActive = !shieldActive;
        }
    }

    // generate a random cooldown time for shield
    int ShieldCooldown()
    {
        return Random.Range(cooldownMin, cooldownMax);
    }


    // raise health, limited to MaxHealth
    public virtual void RaiseHealth()
    {
        mobHealth += 1;

        if (mobHealth > MaxHealth)
        {
            mobHealth = MaxHealth;
        }
    }

    // toggle the state of the spawner
    IEnumerator ToggleSpawnState()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(ShieldCooldown());
            isSpawning = !isSpawning;
        }
    }

    // summon an infantry unit above the tank if isSpawning state is true and reset for another summon
    void SummonInfantry()
    {
        if (isSpawning)
        {
            spawnManager.SpawnMob(mobSummon, gameObject.transform.position.x, gameObject.transform.position.y + spawnOffset, gameObject.transform.position.z, gameObject.transform.rotation );
            isSpawning = false;
        }
    }
}
