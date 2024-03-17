using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // supporter references
    [SerializeField] GameObject support;
    [SerializeField] List<Transform> emptySupportSpawnPoints = new List<Transform>();
    private List<Transform> fullSupportSpawnPoints = new List<Transform>();

    // tank references
    [SerializeField] GameObject tank;
    [SerializeField] List<Transform> emptyTankSpawnPoints = new List<Transform>();
    private List<Transform> fullTankSpawnPoints = new List<Transform>();

    // infantry references
    [SerializeField] GameObject infantry;
    [SerializeField] List<Transform> emptyInfantrySpawnPoints = new List<Transform>();
    private List<Transform> fullInfantrySpawnPoints = new List<Transform>();

    // ranged references
    [SerializeField] GameObject ranged;
    [SerializeField] List<Transform> emptyRangedSpawnPoints = new List<Transform>();
    private List<Transform> fullRangedSpawnPoints = new List<Transform>();

    private void Start()
    {

    }
    private void Update()
    {
        bool testSpawn = Input.GetButtonDown("Fire3");
        if (testSpawn)
        {
            SpawnSupporter();
        }
    }

    // spawn a supporter in a random supporter spawn point as long there are empty points
    void SpawnSupporter()
    {
        if (emptySupportSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptySupportSpawnPoints.Count);
            var selectedPoint = emptySupportSpawnPoints[randomIndex];

            if (selectedPoint != null)
            {
                Instantiate(support, selectedPoint);
                fullSupportSpawnPoints.Add(emptySupportSpawnPoints[randomIndex]);
                emptySupportSpawnPoints.RemoveAt(randomIndex);
            }
        }        
    }

    // spawn a tank in a random tank spawn point as long there are empty points
    void SpawnTank()
    {
        if (emptyTankSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyTankSpawnPoints.Count);
            var selectedPoint = emptyTankSpawnPoints[randomIndex];

            if (selectedPoint != null)
            {
                Instantiate(tank, selectedPoint);
                fullTankSpawnPoints.Add(emptyTankSpawnPoints[randomIndex]);
                emptyTankSpawnPoints.RemoveAt(randomIndex);
            }
        }
    }

    // spawn an infantry in a random infantry spawn point as long there are empty points
    void SpawnInfantry()
    {
        if (emptyInfantrySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyInfantrySpawnPoints.Count);
            var selectedPoint = emptyInfantrySpawnPoints[randomIndex];

            if (selectedPoint != null)
            {
                Instantiate(infantry, selectedPoint);
                fullInfantrySpawnPoints.Add(emptyInfantrySpawnPoints[randomIndex]);
                emptyInfantrySpawnPoints.RemoveAt(randomIndex);
            }
        }
    }
    // spawn a ranged in a random ranged spawn point as long there are empty points
    void SpawnRanged()
    {
        if (emptyRangedSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyRangedSpawnPoints.Count);
            var selectedPoint = emptyRangedSpawnPoints[randomIndex];

            if (selectedPoint != null)
            {
                Instantiate(ranged, selectedPoint);
                fullRangedSpawnPoints.Add(emptyRangedSpawnPoints[randomIndex]);
                emptyRangedSpawnPoints.RemoveAt(randomIndex);
            }
        }
    }
}
