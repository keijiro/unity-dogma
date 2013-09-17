using UnityEngine;
using System.Collections;

public class Stimulator : MonoBehaviour
{
    static Scorekeeper scorekeeperReference;
    public int score;

    Scorekeeper GetScorekeeper() {
        if (scorekeeperReference == null) {
            scorekeeperReference = FindObjectOfType<Scorekeeper>();
        }
        return scorekeeperReference;
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Face") {
            collision.gameObject.SendMessage("BeginAnimation", score > 0 ? "smile" : "anger");
            GetScorekeeper().AddSubScore(score);
        }
    }
}