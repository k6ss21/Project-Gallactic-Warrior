using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    [Header("Projectile Settings")]
    [Space(5)]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPoint;          // A position marking where to Instantiate projectile
    bool canShoot = true;                           // For determining whether Player can shoot or not
    float launchintervalTime = 1f;

    [Header("Audio Settings")]
    [Space(5)]

    [SerializeField] AudioClip shootSfx;             //Shoot AudioClip  
    AudioSource audioSource;                         //Reference to Audio Source

    float vertical;
    [Header("Player Settings")]
    [Space(5)]

    [SerializeField] float speed;                       //Movemet Speed of player


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        //If player press space for shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check whether the player can shoot or not
            if (canShoot)
            {
                audioSource.PlayOneShot(shootSfx);                                                //Play shoot SFX

                GameObject projectile = PlayerProjectilePooledObject.instance.GetPooledObject(); //Get Pooled projectile 
                if (projectile != null)                                                          // if Object is available
                {
                    projectile.transform.position = shootPoint.position;
                    projectile.SetActive(true);                                                  //Enable the projectile
                }
                canShoot = false;
                StartCoroutine(LaunchCooldownRoutine());
            }
        }
    }
    private void FixedUpdate()
    {

        rigidbody2D.velocity = new Vector2(0, vertical * speed); //Add Horizontal velocity to the player
    }


    IEnumerator LaunchCooldownRoutine()                         //Shoot Cooldown Routine 
    {
        yield return new WaitForSeconds(launchintervalTime);
        canShoot = true;
    }



}
