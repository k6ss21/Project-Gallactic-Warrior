using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Projectile Settings")]
    [Space(5)]
    [SerializeField] Transform[] spawnPoints;                                   //Spawn Point
    [SerializeField] float asteroidSpawnIntervalTime;                           //Time interval between spawn.
    bool canSpawn = true;


    private void Update()
    {
        Spawn();                                                                //Spawn Function.
    }

    private void Spawn()
    {
        if (canSpawn)                                                           //Check whether the player can shoot or not.
        {
            SpawnAstroid();
            canSpawn = false;
            StartCoroutine(AstroidSpawnIntervalRoutine());                      //Start coroutine for spawn interval.
        }
    }

    IEnumerator AstroidSpawnIntervalRoutine()
    {
        yield return new WaitForSeconds(asteroidSpawnIntervalTime);
        canSpawn = true;
    }

    private void SpawnAstroid()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);                 //Select any spawn point
        GameObject projectile = AsteroidPooledObject.instance.GetPooledObject();    //Get Pooled projectile
        if (projectile != null)                                                     // if Object is available
        {
            projectile.transform.position = spawnPoints[randomSpawnPoint].position;
            projectile.SetActive(true);                                             //Enable the projectile
            projectile.GetComponent<TrailRenderer>().enabled = true;
        }
    }


}
