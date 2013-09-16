using UnityEngine;
using System.Collections;

public class BottleController : MonoBehaviour
{
    public float squashTime = 0.4f;
    Leap.Controller leap;
    float squash;

    void Awake ()
    {
        leap = new Leap.Controller ();
    }

    void Update ()
    {
        var frame = leap.Frame ();
        var openness = 0.0f;

        if (frame.Hands.Count < 1) {
            openness = 100.0f;
        } else {
            var palmPosition = frame.Hands [0].PalmPosition;
            foreach (var finger in frame.Hands[0].Fingers) {
                var distance = (finger.TipPosition - palmPosition).Magnitude;
                openness += distance * 0.4f;
            }
            openness = Mathf.Clamp (openness - 50.0f, 0.0f, 100.0f);
        }

        Debug.Log (openness);

        squash = 100.0f - openness;

        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, squash);
        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (1, squash);
        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (2, squash);
    }
}