using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BackgroundFit : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    float offset = 3f;

    private void Start()
    {
        FitToScreen();
    }

    private void Update()
    {
        if (Application.isPlaying) return;
        FitToScreen();

    }

    private void FitToScreen()
    {
        float worldHeight = Camera.main.orthographicSize * 2; 
        float worldWidth = worldHeight / Screen.height * Screen.width;
        //for scale game divide world screen width with sprite width and  divide world screen height with sprite height
        transform.localScale = new Vector3(worldWidth / spriteRenderer.sprite.bounds.size.x, worldHeight / spriteRenderer.sprite.bounds.size.y, 1);  
    }
}
