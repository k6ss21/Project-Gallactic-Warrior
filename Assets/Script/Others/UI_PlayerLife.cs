using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class UI_PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject lifePrefab;          //Life icon Prefab. 

    public void UpdateLife(int life)                //Update all child life icons 
    {
        refreshUI();
        for (int i = 0; i < life; i++)
        {
            Instantiate(lifePrefab, this.transform);
        }

    }

    private void refreshUI()                        // Destroy all child life icons 
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.transform.gameObject);
        }
    }
}
