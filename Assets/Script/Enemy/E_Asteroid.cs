using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
public class E_Asteroid : MonoBehaviour
{

    Rigidbody2D rigidbody2D;

    [Header("Projectile Settings")]
    [Space(5)]
    [SerializeField] float minSpeed = 10; // Minimum speed for asteroid 
    [SerializeField] float maxSpeed = 20; // Maximum speed for asteroid 
    float speed;

    public GameObject explosionVfx;

    #region EVENTS
    public static event Action<int> OnAsteroidHitProjectile; //Initialize event if asteroid hit  projectile
    public static event Action<int> OnAsteroidHitPlayer;     //Initialize event if asteroid hit  player
    #endregion


    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed); // Initialize speed when start
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.left * speed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ProjectileDestroy"))          //Destroy this if hits Projectile destroy collider
        {
            DisableGameObject();
        }
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlayExplosionSFX();
            OnAsteroidHitPlayer?.Invoke(50);                //Invoke event with 50 reward coins
            DisableGameObject();
        }

        if (other.CompareTag("PlayerProjectile"))
        {
            AudioManager.instance.PlayExplosionSFX();
            OnAsteroidHitProjectile?.Invoke(10);           //Invoke event with 10 reward coins
            other.gameObject.SetActive(false);
            DisableGameObject();
        }

    }

    void DisableGameObject()
    {
        this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        this.gameObject.SetActive(false);                //Disable GameObject
        Instantiate(explosionVfx, this.transform.position, Quaternion.identity);  //Play ExplsionVFX
    }
}
