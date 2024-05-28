using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    float minutes;
    float seconds;

    [SerializeField] TextMeshProUGUI timeDisplayText; // UI Text Element
    void Update()
    {
        timer += Time.deltaTime;                      //Start the timer
        DisplayTime();
    }

    //Update UI timer Element       
    void DisplayTime()                              
    {
        minutes = Mathf.FloorToInt(timer / 60);                                    // Convert timer to minutes.
        seconds = Mathf.FloorToInt(timer % 60);                                   // Convert timer to seconds.

        timeDisplayText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Change Text element.

    }
}
