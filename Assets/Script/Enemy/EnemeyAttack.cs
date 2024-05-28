using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemeyAttack : MonoBehaviour
{
    PlayerController player;

    [Header("Attack Settings")]
    [Space(5)]
    [SerializeField] float attackIntervalTime; // Time Interval to Attack
    [SerializeField] GameObject enemyProjectilePrefab; //Enemy prefab
    [SerializeField] Transform shootPosition; // // A position marking where to Instantiate projectile
    bool canAttack = true;  // For determining whether Player can shoot or not
    [SerializeField] GameObject explosionVfx;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>(); // Find Player in the scene
    }

    void Update()
    {
        if (canAttack)
        {
            Vector2 moveDir = player.transform.position - shootPosition.position; //  Determining Direction of player
            moveDir.Normalize();
            StartCoroutine(AttackPattern(moveDir)); //Start Attack Coroutine

        }
    }

    IEnumerator AttackPattern(Vector2 direction)
    {
        canAttack = false;
        
        GameObject obj1 = Instantiate(enemyProjectilePrefab, shootPosition.position, Quaternion.identity); // shoot first projectile
        obj1.GetComponent<EnemyProjectile>().SetDirection(direction);                                      // Set Direction of first projectile
        yield return new WaitForSeconds(.1f);                                                               //Wait for 0.1 sec
        GameObject obj2 = Instantiate(enemyProjectilePrefab, shootPosition.position, Quaternion.identity); // shoot 2nd projectile
        obj2.GetComponent<EnemyProjectile>().SetDirection(direction);                                       // Set Direction of 2nd projectile
        yield return new WaitForSeconds(.1f);                                                               //Wait for 0.1 sec
        GameObject obj3 = Instantiate(enemyProjectilePrefab, shootPosition.position, Quaternion.identity); // shoot 3rd projectile
        obj3.GetComponent<EnemyProjectile>().SetDirection(direction);                                       // Set Direction of 3rd projectile
        yield return new WaitForSeconds(attackIntervalTime);                                                 //Wait for 0.1 sec
        canAttack = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))                                   // If Player Projectile hit enemy
        {
            AudioManager.instance.PlayExplosionSFX();
            Instantiate(explosionVfx,this.transform.position,Quaternion.identity);  //Play ExplsionVFX
            GetComponentInParent<EnemySpawner>().Cooldown();                        // Call Cool Down function for spawning next enemy
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);                                               // Destroy this 

        }
    }
}
