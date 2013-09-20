using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour
{
    public GUIStyle scoreStyle;
    public GUIStyle messageStyle;
    int score;
    bool ended;
    float started;

    public int AddSubScore (int delta)
    {
        score += delta;
        return score;
    }

    public void StartGame ()
    {
        score = 0;
        started = 0.8f;
    }

    public void EndGame ()
    {
        ended = true;
    }

    void Update ()
    {
        started = Mathf.Max (started - Time.deltaTime, 0.0f);
    }

    void OnGUI ()
    {
        var rect = new Rect (0, 0, Screen.width, Screen.height);

        GUI.Label (rect, "しあわせ : " + score, scoreStyle);

        if (started > 0.0f) {
            GUI.Label (rect, "はじめ", messageStyle);
        }

        if (ended) {
            GUI.Label (rect, "しゅうりょう", messageStyle);
        }
    }
}