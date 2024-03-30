using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class TankMobController : MobController
{
    // shield reference
    [SerializeField] GameObject shield;

    // allow access to spawn manager
    private SpawnManager spawnManager;

    // reference to summonable mob
    [SerializeField] GameObject mobSummon;

    [SerializeField] int spawnCooldownMin;
    [SerializeField] int spawnCooldownMax;

    // spawner state
    [SerializeField] bool isSpawning = false;

    // spawner offset
    [SerializeField] float spawnOffset = 1.0f;

    protected override void Start()
    {
        base.Start();

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
        if (actionEnabled && !SpawnManager.Instance.gameOver)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
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
        while (true && !SpawnManager.Instance.gameOver)
        {
            yield return new WaitForSecondsRealtime(Random.Range(spawnCooldownMin, spawnCooldownMax));
            isSpawning = !isSpawning;
        }
    }

    // summon an infantry unit above the tank if isSpawning state is true and reset for another summon
    void SummonInfantry()
    {
        if (isSpawning && !SpawnManager.Instance.gameOver)
        {
            Instantiate(mobSummon, new Vector3(transform.position.x, transform.position.y + spawnOffset, transform.position.z), transform.rotation);
            isSpawning = false;
            SpawnManager.IncrementEnemyCount();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // mob shield blocks player bullet
        if (other.gameObject.CompareTag("bullet-player"))
        {
            other.gameObject.GetComponent<BulletPlayerController>().fired = false;
            other.gameObject.SetActive(false);
        }
    }
}
