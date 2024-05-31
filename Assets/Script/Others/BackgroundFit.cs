using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BackgroundFit : MonoBehaviour
{

   public SpriteRenderer spriteRenderer;
    float offset = 3f;

    private void Start() {
        FitToScreen();
    }

    private void Update()
    {
        if(Application.isPlaying) return;
        FitToScreen();

    }

    private void FitToScreen()
    {
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Debug.Log(worldScreenHeight + ", " +Camera.main.pixelHeight);

         transform.localScale = new Vector3(worldScreenWidth /spriteRenderer.sprite.bounds.size.x,worldScreenHeight / spriteRenderer.sprite.bounds.size.y , 1);
    }
}
