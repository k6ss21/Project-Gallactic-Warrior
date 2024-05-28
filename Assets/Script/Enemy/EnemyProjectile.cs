using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 10;      //Enemy projectile speed
    Vector2 moveDir;                        //Moving Direction

    public static Action OnEnemyProjectilehit; //Initialize event if asteroid hit  Player

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * speed;  //Add velocity to projectile
    }

    public void SetDirection(Vector2 direction)
    {
        moveDir = direction;                                                //Set move Direction
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //Calculating Angle from direction 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  //Rotating projectile towards player
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ProjectileDestroy"))              //If Enemy Projectile hit Projectile Destroy Collider
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player"))                         // If Enemy Projectile hit Player
        {
            other.GetComponent<PlayerHealth>().TakeSmallhit(); //Call Small hit Function     
            Destroy(this.gameObject);
        }
    }
}
