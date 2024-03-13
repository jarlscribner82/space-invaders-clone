using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMobPooler : MonoBehaviour
{
    // make pooler accessible
    public static BulletMobPooler SharedInstance;
    // create a list of pooled objects
    [SerializeField] List<GameObject> pooledObjects;
    // refernce for object to be pooled
    [SerializeField] GameObject objectToPool;
    // limit the number of objects to pool
    [SerializeField] int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerBullets();
    }

    // Loop through list of pooled objects,deactivating them and adding them to the list
    private void CreatePlayerBullets()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    // get an object from the pool
    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled object is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}
