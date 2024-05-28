using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [Space(5)]
    [SerializeField] int totalLives = 3; // Total player's life at the start

    int currentLives;                   // The player's health right now

    int smallhitCount = 0;

    [Header("UI")]
    [Space(5)]
    [SerializeField] UI_PlayerLife uI_PlayerLife;     //PLayer Life UI Reference
    [SerializeField] Canvas gameOverCanvas;           //Game Over UI Refernce

    [SerializeField] Economy economy;

    private void Start()
    {
        // Initialiase the player's current life
        currentLives = totalLives;
        uI_PlayerLife.UpdateLife(currentLives);
        gameOverCanvas.gameObject.SetActive(false);
    }

    void TakeLife()
    {
        // Deduct the one life  from the player's current life
        currentLives -= 1;
        uI_PlayerLife.UpdateLife(currentLives);

        if (currentLives <= 0)                          // If the player has no life left 
        {
            currentLives = 0;
            economy.SaveData();                        // Save earned coin
            Time.timeScale = 0;
            gameOverCanvas.gameObject.SetActive(true); //Shoe GAME OVER Canvas
        }
    }

    public void TakeSmallhit()
    {
        // Take small hit from enemy
        smallhitCount += 1;
        if (smallhitCount >= 9)                        // If the player has taken more than 9 small Hit then take ONE LIFE
        {
            TakeLife();
            smallhitCount = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D other)         //if Enemy Hit player take life
    {
        if (other.CompareTag("Enemy"))
        {
            TakeLife();
        }
    }
}
