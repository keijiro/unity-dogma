using UnityEngine;
using System.Collections;

public class SprayController : MonoBehaviour
{
    public float interval = 0.1f;
    public float velocity = 5.0f;
    public float randomFactor = 1.0f;
    public GameObject mayoPrefab;
    BottleController bottle;

    void Awake ()
    {
        bottle = FindObjectOfType<BottleController> ();
    }

    GameObject Spray ()
    {
        var v = transform.forward * velocity;
        v += transform.right * Random.Range (-randomFactor, randomFactor);
        v += transform.up * Random.Range (-randomFactor, randomFactor);

        var go = Instantiate (mayoPrefab) as GameObject;
        go.rigidbody.velocity = v;

        return go;
    }

    IEnumerator Start ()
    {
        while (true) {
            while (!bottle.Squashed) {
                yield return null;
            }

            var prevInstance = Spray ();
            yield return new WaitForSeconds (interval);

            while (bottle.Squashed) {
                var instance = Spray ();

                var joint = instance.AddComponent<ConfigurableJoint> ();
                joint.connectedBody = prevInstance.rigidbody;

                joint.xMotion = ConfigurableJointMotion.Limited;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Limited;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;

                prevInstance = instance;
                yield return new WaitForSeconds (interval);
            }
        }
    }
}