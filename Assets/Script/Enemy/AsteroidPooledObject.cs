using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPooledObject : MonoBehaviour
{
    //Singleton Pattern
    public static AsteroidPooledObject instance;
    private List<GameObject> pooledObjects = new List<GameObject>(); //List for Pooled object

    private int amount = 30;                                         // Amount to pool

    [SerializeField] private GameObject[] asteroidPrefab;            // Reference to GameObjects to Pool

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amount; i++)                                     // For Loop to Instantiate  Object to List
        {
            int randomAstroid = Random.Range(0, asteroidPrefab.Length);
            GameObject obj = Instantiate(asteroidPrefab[randomAstroid]);
            obj.SetActive(false);                                           // Disable Object 
            pooledObjects.Add(obj);                                         //Adding to pool List
        }
    }

    public GameObject GetPooledObject()                            //Method to return GameObject
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)             // if pooled object is not active or available
            {
                return pooledObjects[i];
            }
        }
        return null;                                            // else return null.
    }
}
