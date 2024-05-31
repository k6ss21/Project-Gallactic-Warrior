using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class FitInScreen : MonoBehaviour
{
    Camera camera;

    public Vector3 offset;

    public AnchorPoint anchorPoint;
    Vector3 anchorPosition;

    private void Start()
    {

        SetAnchor();
    }

    public void FindAnchorPoint()
    {
        switch (anchorPoint)
        {
            case AnchorPoint.leftCentre:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight / 2, 0));
                break;
            case AnchorPoint.leftTop:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight, 0));
                break;
            case AnchorPoint.leftBottom:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
                break;
            case AnchorPoint.centreBottom:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, 0, 0));
                break;
            case AnchorPoint.centre:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0));
                break;
            case AnchorPoint.centreTop:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth / 2, camera.pixelHeight, 0));
                break;
            case AnchorPoint.rightTop:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 0));
                break;
            case AnchorPoint.rightCentre:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight / 2, 0));
                break;
            case AnchorPoint.rightBottom:
                anchorPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0, 0));
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Application.isPlaying) return;
        SetAnchor();

    }


    private void SetAnchor()
    {
        camera = Camera.main;
        FindAnchorPoint();
        transform.position = new Vector3(anchorPosition.x, anchorPosition.y, 0) + offset;
    }


}



public enum AnchorPoint
{
    leftCentre,
    leftTop,
    leftBottom,
    centre,
    centreTop,
    centreBottom,
    rightTop,
    rightCentre,
    rightBottom



}
