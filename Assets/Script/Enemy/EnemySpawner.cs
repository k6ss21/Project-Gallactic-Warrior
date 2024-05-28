using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
     [Header("Spawn Settings")]
    [Space(5)]
    [SerializeField] GameObject enemyShip;
    [SerializeField] float initialSpawnInterval;    // Initial Spawn time
    [SerializeField] float minSpawnInterval;        //Minimum spawn interval
    [SerializeField] float maxSpawnInterval;        //Maximum spawn interval

    bool canSpawn = false;                          //For determining whether can Spawn or not;

    private void Start()
    {
        StartCoroutine(SpawnCoolDown(initialSpawnInterval));  //routine when starting the game
    }
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Instantiate(enemyShip, this.transform);                     // Spawn Enemy as a child
        } 


    }

    public void Cooldown()                                              //Cooldown for spawning next enemy
    {
        float time = Random.Range(minSpawnInterval, maxSpawnInterval);  // Determine a random time 
        StartCoroutine(SpawnCoolDown(time));
    }

    public IEnumerator SpawnCoolDown(float spawnInterval )
    {
        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }
}
