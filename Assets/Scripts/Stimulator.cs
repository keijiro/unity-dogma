using UnityEngine;
using System.Collections;

public class Stimulator : MonoBehaviour
{
    public float score = 1.0f;

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Face") {
            collision.gameObject.SendMessage("BeginAnimation", score > 0.0f ? "smile" : "anger");
        }
    }
}