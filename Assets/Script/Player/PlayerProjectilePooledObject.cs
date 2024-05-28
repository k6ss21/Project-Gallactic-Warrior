using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectilePooledObject : MonoBehaviour
{
    //Singleton Pattern
    public static PlayerProjectilePooledObject instance;

    private List<GameObject> pooledObjects = new List<GameObject>(); //List for Pooled object

    private int amount = 10;                                        // Amount to pool

    [SerializeField] private GameObject playerProjectilePrefab;     // Reference to GameObject to Pool

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amount; i++)                // For Loop to Instantiate  Object to List
        {
            GameObject obj = Instantiate(playerProjectilePrefab,transform.position,Quaternion.identity);
            obj.SetActive(false);                       // Disable Object 
            pooledObjects.Add(obj);                     //Adding to pool List
        }
    }

    public GameObject GetPooledObject()                 //Method to return GameObject
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)     // if pooled object is not active or available
            {
                return pooledObjects[i];
            }
        }
        return null;                                   // else return null.
    }

}
