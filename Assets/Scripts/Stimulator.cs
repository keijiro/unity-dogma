using UnityEngine;
using System.Collections;

public class Stimulator : MonoBehaviour
{
    static Scorekeeper scorekeeperReference;
    public int score;

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Face") {
            collision.gameObject.BroadcastMessage("BeginAnimation", score > 0 ? "smile" : "anger");
            if (scorekeeperReference == null) {
                scorekeeperReference = FindObjectOfType<Scorekeeper>();
            }
            if (scorekeeperReference != null) {
                scorekeeperReference.AddSubScore(score);
            }
        }
    }
}