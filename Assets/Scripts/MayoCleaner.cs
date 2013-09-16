using UnityEngine;
using System.Collections;

public class MayoCleaner : MonoBehaviour
{
    void Update ()
    {
        if (transform.position.y < -5.0f) {
            Destroy (gameObject);
        }
    }
}