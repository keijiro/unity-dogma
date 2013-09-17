using UnityEngine;
using System.Collections;

public class Bottler : MonoBehaviour
{
    public GameObject mayoBottlePrefab;
    public GameObject tabascoBottlePrefab;
    public float chanceOfMayo = 0.7f;
    public float waitFor = 1.5f;
    public float waitMultiplier = 0.95f;

    GameObject SelectPrefabRandomly ()
    {
        return Random.value < chanceOfMayo ? mayoBottlePrefab : tabascoBottlePrefab;
    }

    IEnumerator Start ()
    {
        GameObject prevBottle = null;

        while (true) {
            Camera.main.GetComponent<CameraController>().ZoomDown();
            yield return new WaitForSeconds(0.5f);
            var bottle = Instantiate (SelectPrefabRandomly ()) as GameObject;
            Camera.main.GetComponent<CameraController>().ZoomUp();
            yield return new WaitForSeconds(0.5f);

            yield return new WaitForSeconds (waitFor);

            if (prevBottle != null) {
                Destroy (prevBottle);
            }

            bottle.GetComponentInChildren<SprayController> ().StopCoroutine("Start");
            bottle.GetComponent<BottleMove> ().StartExit ();
            prevBottle = bottle;

            waitFor *= waitMultiplier;
        }
    }
}