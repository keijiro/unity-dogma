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

        // 1st mayo.
        cameraMove.ZoomUp ();
        var bottle = Instantiate(mayoBottlePrefab) as GameObject;

        // Wait for pressing the jump button.
        while (!Input.GetButtonDown("Jump")) {
            yield return null;
        }

        // Leaving.
        cameraMove.ZoomDown ();
        bottle.GetComponent<BottleMove> ().StartExit ();
        yield return new WaitForSeconds (0.5f);
        Destroy (bottle);

        // 1st Tabasco.
        cameraMove.ZoomUp ();
        bottle = Instantiate(tabascoBottlePrefab) as GameObject;

        // Wait for pressing the jump button.
        while (!Input.GetButtonDown("Jump")) {
            yield return null;
        }

        // Leaving.
        cameraMove.ZoomDown ();
        bottle.GetComponent<BottleMove> ().StartExit ();
        yield return new WaitForSeconds (0.5f);
        Destroy (bottle);

        // Start game.
        FindObjectOfType<Scorekeeper> ().StartGame ();
        audio.Play ();
        yield return new WaitForSeconds (1.0f);

        while (bottleCount-- > 0) {
            bottle = Instantiate (SelectPrefabRandomly ()) as GameObject;

            cameraMove.ZoomUp ();
            yield return new WaitForSeconds (Mathf.Max (waitFor, 0.25f));
            waitFor *= waitMultiplier;
            cameraMove.ZoomDown ();

            bottle.GetComponentInChildren<SprayController> ().StopCoroutine ("Start");
            bottle.GetComponent<BottleMove> ().StartExit ();

            yield return new WaitForSeconds (0.5f);
            Destroy (bottle);
        }

        FindObjectOfType<Scorekeeper> ().EndGame ();
    }
}