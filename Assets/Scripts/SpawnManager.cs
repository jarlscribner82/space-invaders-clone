using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance { get; private set; }

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

    // singleton setup
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        SpawnWave();
    }
    private void Update()
    {
        SpawnWave();
        //if (Input.GetButtonDown("Fire3"))
        //{
        //    SpawnMob(support, 0, 0, -5, gameObject.transform.rotation);
        //}
    }

    // overloaded spawn method to allow mobs to "summon" more mobs
    // parameters are for the object to be spawned, x,y, and z coordinates and rotation (the necceasary parameters for Instantiate)
    public void SpawnMob (GameObject mobType, float xPos, float yPos, float zPos, Quaternion rotation)
    {

        Instantiate(mobType, new Vector3(xPos, yPos, zPos), rotation);

        enemyCount++;
    }

    // abrtracted spawner for any mob type
    // parameters corrospond to to the references for each mob in the declarations at the top of the page
    void SpawnMob(GameObject mobType, List<Transform> emptySpawnPoints, List<Transform> fullSpawnPoints, ref bool pointsFull)
    {
        if (emptySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, emptySpawnPoints.Count);
            var selectedPoint = emptySpawnPoints[randomIndex];

            if (selectedPoint != null)
            {
                Instantiate(mobType, selectedPoint);
                fullSpawnPoints.Add(emptySpawnPoints[randomIndex]);
                emptySpawnPoints.RemoveAt(randomIndex);
            }

            if (emptySpawnPoints.Count <= 0)
            {
                pointsFull = true;
            }

            enemyCount++;
        }
    }

    // abstracted resetter for any mob type
    void ResetSpawnPoints(List<Transform> emptySpawnPoints, List<Transform> fullSpawnPoints, ref bool pointsFull)
    {
        foreach (Transform t in fullSpawnPoints)
        {
            emptySpawnPoints.Add(t);
        }
        fullSpawnPoints.Clear();

        pointsFull = false;
    }

    // ensure a random number for type selection every call
    int MobChooser()
    {
        return Random.Range(1, 5);
    }

    // sets winninng conditions and proceeds if they aren't met
    // spawn a random mob type only if there are empty spaces left
    // works recursively until a suitable choice is made
    void ChooseMobType()
    {
        if (infantryFull && rangedFull && supporterFull && tankFull && waveNumber > 53)
        {
            Debug.Log("VICTORY");
            Time.timeScale = 0;
        }
        else
        {
            int chooseMobType = MobChooser();

            // spawn an infantry
            if (chooseMobType == 1)
            {
                if (infantryFull)
                {
                    ChooseMobType();
                }
                else
                {
                    SpawnMob(infantry, emptyInfantrySpawnPoints, fullInfantrySpawnPoints, ref infantryFull);
                }
            }

            // spawn a supporter
            if (chooseMobType == 2)
            {
                if (supporterFull)
                {
                    ChooseMobType();
                }
                else
                {
                    SpawnMob(support, emptySupportSpawnPoints, fullSupportSpawnPoints, ref supporterFull);
                }
            }


            // spaw a tank
            if (chooseMobType == 3)
            {
                if (tankFull)
                {
                    ChooseMobType();
                }
                else
                {
                    SpawnMob(tank, emptyTankSpawnPoints, fullTankSpawnPoints, ref tankFull);
                }
            }

            // spawn a ranged
            if (chooseMobType == 4)
            {
                if (rangedFull)
                {
                    ChooseMobType();
                }
                else
                {
                    SpawnMob(ranged, emptyRangedSpawnPoints, fullRangedSpawnPoints, ref rangedFull);
                }
            }
        }
    }

    // spawn a wave of mobs
    void SpawnWave()
    {
        if (enemyCount == 0)
        {
            ResetSpawnPoints(emptyInfantrySpawnPoints, fullInfantrySpawnPoints, ref infantryFull);

            ResetSpawnPoints(emptyTankSpawnPoints, fullTankSpawnPoints, ref tankFull);

            ResetSpawnPoints(emptyRangedSpawnPoints, fullRangedSpawnPoints, ref rangedFull);

            ResetSpawnPoints(emptySupportSpawnPoints, fullSupportSpawnPoints, ref supporterFull);;

            for (int i = 0; i < waveNumber; i++)
            {
                ChooseMobType();
            }

            waveNumber++;
        }
    }
}
