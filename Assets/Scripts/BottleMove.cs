using UnityEngine;
using System.Collections;

public class BottleMove : MonoBehaviour
{
    public float width = 3.0f;
    Vector3 target;

    void Start ()
    {
        transform.localPosition = Vector3.forward * width;
    }

    public void StartExit ()
    {
        target = Vector3.forward * -width;
    }

    void Update ()
    {
        transform.localPosition = Vector3.Lerp (target, transform.localPosition, Mathf.Exp (-8.0f * Time.deltaTime));
    }
}