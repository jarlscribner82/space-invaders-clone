using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject support;
    [SerializeField] List<Transform> emptySupportSpawnPoints = new List<Transform>();
    private List<Transform> fullSupportSpawnPoints = new List<Transform>();

    [SerializeField] GameObject tank;
    [SerializeField] List<Transform> emptyTankSpawnPoints = new List<Transform>();
    private List<Transform> fullTankSpawnPoints = new List<Transform>();

    [SerializeField] GameObject infantry;
    [SerializeField] List<Transform> emptyInfantrySpawnPoints = new List<Transform>();
    private List<Transform> fullInfantrySpawnPoints = new List<Transform>();

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
            SpawnInfantry();
            SpawnRanged();
            SpawnTank();
        }
    }
    void SpawnSupporter()
    {
        if (emptySupportSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptySupportSpawnPoints.Count);
            var selectedPoint = emptySupportSpawnPoints[randomIndex];

            if (selectedPoint != null && emptySupportSpawnPoints.Count > 0)
            {

                Instantiate(support, selectedPoint);
                fullSupportSpawnPoints.Add(emptySupportSpawnPoints[randomIndex]);
                emptySupportSpawnPoints.RemoveAt(randomIndex);
            }
        }        
    }

    void SpawnTank()
    {
        if (emptyTankSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyTankSpawnPoints.Count);
            var selectedPoint = emptyTankSpawnPoints[randomIndex];

            if (selectedPoint != null && emptyTankSpawnPoints.Count > 0)
            {

                Instantiate(tank, selectedPoint);
                fullTankSpawnPoints.Add(emptyTankSpawnPoints[randomIndex]);
                emptyTankSpawnPoints.RemoveAt(randomIndex);
            }
        }
    }

    void SpawnInfantry()
    {
        if (emptyInfantrySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyInfantrySpawnPoints.Count);
            var selectedPoint = emptyInfantrySpawnPoints[randomIndex];

            if (selectedPoint != null && emptyInfantrySpawnPoints.Count > 0)
            {

                Instantiate(infantry, selectedPoint);
                fullInfantrySpawnPoints.Add(emptyInfantrySpawnPoints[randomIndex]);
                emptyInfantrySpawnPoints.RemoveAt(randomIndex);
            }
        }
    }

    void SpawnRanged()
    {
        if (emptyRangedSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyRangedSpawnPoints.Count);
            var selectedPoint = emptyRangedSpawnPoints[randomIndex];

            if (selectedPoint != null && emptyRangedSpawnPoints.Count > 0)
            {

                Instantiate(ranged, selectedPoint);
                fullRangedSpawnPoints.Add(emptyRangedSpawnPoints[randomIndex]);
                emptyRangedSpawnPoints.RemoveAt(randomIndex);
            }
        }
    }
}
