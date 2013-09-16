using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float zoomFOV = 5.0f;
    float initialFOV;
    float zoomTarget;
    float zoom;

    void Awake ()
    {
        initialFOV = camera.fieldOfView;
    }
        
    void Update ()
    {
        zoom = zoomTarget - (zoomTarget - zoom) * Mathf.Exp (-8.0f * Time.deltaTime);
        camera.fieldOfView = initialFOV - zoom * zoomFOV;
    }

    public void ZoomUp ()
    {
        zoomTarget = 1.0f;
    }

    public void ZoomDown ()
    {
        zoomTarget = 0.0f;
    }
}