using UnityEngine;
using System.Collections;

public class Bottler : MonoBehaviour
{
    public GameObject mayoBottlePrefab;
    public GameObject tabascoBottlePrefab;
    public float chanceOfMayo = 0.7f;
    public float waitFor = 1.5f;

    GameObject SelectPrefabRandomly ()
    {
        return Random.value < chanceOfMayo ? mayoBottlePrefab : tabascoBottlePrefab;
    }

    IEnumerator Start ()
    {
        GameObject prevBottle = null;

        while (true) {
            var bottle = Instantiate (SelectPrefabRandomly ()) as GameObject;
            yield return new WaitForSeconds (waitFor);

            if (prevBottle != null) {
                Destroy (prevBottle);
            }

            bottle.GetComponentInChildren<SprayController> ().StopCoroutine("Start");
            bottle.GetComponent<BottleMove> ().StartExit ();
            prevBottle = bottle;
        }
    }
}