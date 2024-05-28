using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 10;                  // Speed of projectile


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.right * speed; //Add  velocity to the projectile
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ProjectileDestroy"))   //If projectile hit projectileDestroyCollider
        {
          gameObject.SetActive(false);              // Disable the projectile (Destroy)
        }
    }
}
