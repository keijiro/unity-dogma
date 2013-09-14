using UnityEngine;
using System.Collections;

public class BottleController : MonoBehaviour {
    public float squashTime = 0.4f;

    float squash;

	void Update () {
        if (Input.GetMouseButton (0)) {
            squash = Mathf.Min (squash + Time.deltaTime * 100.0f / squashTime, 100.0f);
        } else {
            squash = Mathf.Max (squash - Time.deltaTime * 100.0f / squashTime, 0);
        }

        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, squash);
        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (1, squash);
        GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (2, squash);
    }
}