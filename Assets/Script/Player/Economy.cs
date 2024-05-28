using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Economy : MonoBehaviour
{
    int initialCoins;
    public int collectedCoins;

    public TextMeshProUGUI coinText;

    private void OnEnable()
    {
        E_Asteroid.OnAsteroidHitProjectile += AddCoin;  //Subscribing to Event
        E_Asteroid.OnAsteroidHitPlayer += DeductCoin;   //Subscribing to Event
    }

    private void OnDisable()
    {
        E_Asteroid.OnAsteroidHitProjectile -= AddCoin;  //Unsubscribing  Event
        E_Asteroid.OnAsteroidHitPlayer -= DeductCoin;   //Unsubscribing  Event
    }

    private void Start()
    {

        initialCoins = LoadData();                      //Load Saved data and initialize 
        collectedCoins = initialCoins;
        UpdateCoinTextUI();                             //Initial UI Update
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void AddCoin(int value)                     //Method to Add coin
    {
        collectedCoins += value;
        UpdateCoinTextUI();
    }

    public void DeductCoin(int value)       //Method to Deduct coin
    {
        collectedCoins -= value;
        UpdateCoinTextUI();
        if (collectedCoins <= 0)           //if collected coin is less than or equal to 0
        {
            collectedCoins = 0;            // set collected coin as 0
            UpdateCoinTextUI();
        }
    }

    private void UpdateCoinTextUI()     // Update UI Coin Text
    {
        coinText.text = collectedCoins.ToString();
    }

    public void SaveData()             // Save Collected Coin if Collected coin is greater than 200
    {
        if (collectedCoins >= 200)
        {
            PlayerPrefs.SetInt("Coins", collectedCoins);
            PlayerPrefs.Save();
        }


    }

    public int LoadData() // Load Saved data
    {
        return PlayerPrefs.GetInt("Coins");
    }

}
