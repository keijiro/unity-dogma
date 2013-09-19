using UnityEngine;
using System.Collections;

public class Bottler : MonoBehaviour
{
    public GameObject mayoBottlePrefab;
    public GameObject tabascoBottlePrefab;
    public float chanceOfMayo = 0.7f;
    public float waitFor = 1.5f;
    public float waitMultiplier = 0.95f;
    public float bottleCount = 20;

    GameObject SelectPrefabRandomly ()
    {
        return Random.value < chanceOfMayo ? mayoBottlePrefab : tabascoBottlePrefab;
    }

    IEnumerator Start ()
    {
        var cameraMove = Camera.main.GetComponent<CameraController> ();

        GameObject prevBottle = null;

        while (bottleCount-- > 0) {
            cameraMove.ZoomDown ();

            yield return new WaitForSeconds (0.5f);

            var bottle = Instantiate (SelectPrefabRandomly ()) as GameObject;
            cameraMove.ZoomUp ();

            if (prevBottle != null) {
                Destroy (prevBottle, 0.5f);
            }

            yield return new WaitForSeconds (waitFor);

            bottle.GetComponentInChildren<SprayController> ().StopCoroutine ("Start");
            bottle.GetComponent<BottleMove> ().StartExit ();

            waitFor *= waitMultiplier;
            prevBottle = bottle;
        }

        yield return new WaitForSeconds (0.5f);

        FindObjectOfType<Scorekeeper> ().EndGame ();
    }
}