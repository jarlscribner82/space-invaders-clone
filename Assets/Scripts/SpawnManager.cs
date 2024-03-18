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
    private bool supporterFull = false;

    // tank references
    [SerializeField] GameObject tank;
    [SerializeField] List<Transform> emptyTankSpawnPoints = new List<Transform>();
    private List<Transform> fullTankSpawnPoints = new List<Transform>();
    private bool tankFull = false;

    // infantry references
    [SerializeField] GameObject infantry;
    [SerializeField] List<Transform> emptyInfantrySpawnPoints = new List<Transform>();
    private List<Transform> fullInfantrySpawnPoints = new List<Transform>();
    private bool infantryFull = false;

    // ranged references
    [SerializeField] GameObject ranged;
    [SerializeField] List<Transform> emptyRangedSpawnPoints = new List<Transform>();
    private List<Transform> fullRangedSpawnPoints = new List<Transform>();
    private bool rangedFull = false;

    [SerializeField] private int waveNumber = 1;
    public int enemyCount;

    private void Start()
    {
        SpawnWave();
    }
    private void Update()
    {
        SpawnWave();
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

                enemyCount ++;
            }

            if (emptySupportSpawnPoints.Count <= 0)
            {
                supporterFull = true;
            }
        }        
    }

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetSupporterPoints()
    {
        if (supporterFull)
        {
            foreach (Transform t in fullSupportSpawnPoints)
            {
                emptySupportSpawnPoints.Add(t);                
            }            
            fullSupportSpawnPoints.Clear();

            supporterFull = false;
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

                enemyCount++;
            }

            if (emptyTankSpawnPoints.Count <= 0)
            {
                tankFull = true;
            }
        }
    }

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetTankPoints()
    {
        if (tankFull)
        {
            foreach (Transform t in fullTankSpawnPoints)
            {
                emptyTankSpawnPoints.Add(t);
            }
            fullTankSpawnPoints.Clear();

            tankFull = false;
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

                enemyCount++;
            }

            if (emptyInfantrySpawnPoints.Count <= 0)
            {
                infantryFull = true;
            }
        }
    }

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetInfantryPoints()
    {
        if (infantryFull)
        {
            foreach (Transform t in fullInfantrySpawnPoints)
            {
                emptyInfantrySpawnPoints.Add(t);
            }
            fullInfantrySpawnPoints.Clear();

            infantryFull = false;
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

                enemyCount++;
            }

            if (emptyRangedSpawnPoints.Count <= 0)
            {
                rangedFull = true;
            }
        }
    }

    // take all objects in full points and transfer them back to empty points then empty the full points list
    void ResetRangedPoints()
    {
        if (rangedFull)
        {
            foreach (Transform t in fullRangedSpawnPoints)
            {
                emptyRangedSpawnPoints.Add(t);
            }
            fullRangedSpawnPoints.Clear();

            rangedFull = false;
        }
    }

    int MobChooser()
    {
        return Random.Range(1, 5);
    }

    void ChooseMobType()
    {
        int chooseMobType = MobChooser();

        if (chooseMobType == 1)
        {
            SpawnInfantry();

            if (infantryFull)
            {
                MobChooser();
            }
        }

        if (chooseMobType == 2)
        {
            SpawnSupporter();

            if (supporterFull)
            {
                MobChooser();
            }
        }

        if (chooseMobType == 3)
        {
            SpawnTank();

            if (tankFull)
            {
                MobChooser();
            }
        }

        if (chooseMobType == 4)
        {
            SpawnRanged();

            if (rangedFull)
            {
                MobChooser();
            }
        }
    }

    // spawn a wave of mobs
    void SpawnWave()
    {
        if (enemyCount == 0)
        {
            ResetInfantryPoints();
            ResetTankPoints();
            ResetRangedPoints();
            ResetSupporterPoints();

            for (int i = 0; i < waveNumber; i++)
            {
                ChooseMobType();
            }

            waveNumber++;
        }
    }
}
