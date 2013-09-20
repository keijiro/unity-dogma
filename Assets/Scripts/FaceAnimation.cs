using UnityEngine;
using System.Collections;

public class FaceAnimation : MonoBehaviour
{
    public AudioClip smileAudioClip;
    public AudioClip angerAudioClip;
    float shake;
    float smile;

    void Update ()
    {
        Vector3 waving = new Vector3 (
            Mathf.Sin (Time.time * 2.621f),
            Mathf.Sin (Time.time * 2.973f),
            Mathf.Sin (Time.time * 1.789f)
        );
        var hop = 0.5f * smile * Mathf.Abs (Mathf.Sin (Time.time * 20.0f));
        transform.localPosition = waving * 0.1f + Random.onUnitSphere * shake * 0.6f + Vector3.up * hop;

        var smr = GetComponent<SkinnedMeshRenderer> ();
        var chew = 0.5f * (Mathf.Sin (Time.time * 30.0f) + 1.0f);
        smr.SetBlendShapeWeight (2, Mathf.Min (smile * 200.0f, 100.0f) * chew);
        smr.SetBlendShapeWeight (4, Mathf.Min (shake * 2000.0f, 100.0f));

        shake *= Mathf.Exp (-10.0f * Time.deltaTime);
        smile = Mathf.Max (0.0f, smile - Time.deltaTime);
    }

    public void BeginAnimation (string mode)
    {
        if (mode == "anger") {
            shake = 0.3f;
            audio.clip = angerAudioClip;
            audio.Play ();
        } else if (mode == "smile") {
            smile = 0.6f;
            audio.clip = smileAudioClip;
            audio.Play ();
        }
    }
}