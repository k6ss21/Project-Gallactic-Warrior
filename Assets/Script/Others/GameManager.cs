using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameStartCanvas;            //Reference to Game Start Canvas
    [SerializeField] Canvas gameHUD;
    [SerializeField] PlayerController player;

    private void Start()
    {
        Time.timeScale = 0f;                            //   Start with time scale 0
        gameStartCanvas.gameObject.SetActive(true);     // Start with Start Game canvas Active
        gameHUD.gameObject.SetActive(false);            //Disable game HUD

    }


    public void StartGame()
    {
        Time.timeScale = 1f;                            // when start game button press , Set time scale to 1.
        gameStartCanvas.gameObject.SetActive(false);    // Disable game start canvas 
        gameHUD.gameObject.SetActive(true);             //Enable game HUD
    }

    public void ExitGame()
    {
        Application.Quit();                             //Quit the game when exit button pressed;
    }
}
