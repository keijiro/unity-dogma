using UnityEngine;
using System.Collections;

public class SillyStringGenerator : MonoBehaviour
{
    public float interval = 0.1f;
    public float velocity = 5.0f;
    public float randomFactor = 1.0f;
    public GameObject element;

    GameObject SpawnElement() {
        var v = transform.forward * velocity;
        v += transform.right * Random.Range (-randomFactor, randomFactor);
        v += transform.up * Random.Range (-randomFactor, randomFactor);

        var go = Instantiate (element) as GameObject;
        go.rigidbody.AddForce(v, ForceMode.VelocityChange);

        return go;
    }

    IEnumerator Start ()
    {
        while (true) {
            while (!Input.GetMouseButton(0)) {
                yield return null;
            }

            var prev = SpawnElement();
            yield return new WaitForSeconds (interval);

            while (Input.GetMouseButton (0)) {
                var elm = SpawnElement();

                var joint = elm.AddComponent<ConfigurableJoint>();
                joint.connectedBody = prev.rigidbody;
                
                var limit = new SoftJointLimit ();
//                limit.limit = 0.1f;
//                limit.spring = 40.0f;
                joint.linearLimit = limit;

                /*
                limit.limit = 10.0f;
                joint.angularYLimit = limit;
                joint.angularZLimit = limit;
                joint.highAngularXLimit = limit;
                joint.lowAngularXLimit = limit;
                */
                
                joint.xMotion = ConfigurableJointMotion.Limited;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Limited;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;

                prev = elm;
                yield return new WaitForSeconds (interval);
            }
        }
    }
}
