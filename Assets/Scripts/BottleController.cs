using UnityEngine;
using System.Collections;

public class BottleController : MonoBehaviour
{
    Leap.Controller leap;
    float squash;

    public bool Squashed {
        get {
            return squash > 50.0f;
        }
    }

    void Awake ()
    {
        leap = new Leap.Controller ();
    }

    float GetOpenness ()
    {
        var frame = leap.Frame ();

        if (frame.Hands.Count < 1) {
            return 100.0f;
        }

        var sum = 0.0f;

        var palmPosition = frame.Hands [0].PalmPosition;
        foreach (var finger in frame.Hands[0].Fingers) {
            var distance = (finger.TipPosition - palmPosition).Magnitude;
            sum += distance * 0.4f;
        }

        return Mathf.Clamp (sum - 50.0f, 0.0f, 100.0f);
    }

    void Update ()
    {
        squash = Mathf.Lerp (squash, 100.0f - GetOpenness (), 0.5f);

        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer> ();
        smr.SetBlendShapeWeight (0, squash);
    }
}