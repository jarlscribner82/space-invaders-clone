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
            SpawnRanged();
        }

        if (emptyRangedSpawnPoints.Count == 0)
        {
            ResetRangedPoints();
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

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetSupporterPoints()
    {
        if (fullSupportSpawnPoints.Count > 0)
        {
            foreach (Transform t in fullSupportSpawnPoints)
            {
                emptySupportSpawnPoints.Add(t);                
            }            
            fullSupportSpawnPoints.Clear();
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

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetTankPoints()
    {
        if (fullTankSpawnPoints.Count > 0)
        {
            foreach (Transform t in fullTankSpawnPoints)
            {
                emptyTankSpawnPoints.Add(t);
            }
            fullTankSpawnPoints.Clear();
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

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetInfantryPoints()
    {
        if (fullInfantrySpawnPoints.Count > 0)
        {
            foreach (Transform t in fullInfantrySpawnPoints)
            {
                emptyInfantrySpawnPoints.Add(t);
            }
            fullInfantrySpawnPoints.Clear();
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

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetRangedPoints()
    {
        if (fullRangedSpawnPoints.Count > 0)
        {
            foreach (Transform t in fullRangedSpawnPoints)
            {
                emptyRangedSpawnPoints.Add(t);
            }
            fullRangedSpawnPoints.Clear();
        }
    }

}
