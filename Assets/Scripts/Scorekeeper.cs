using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour
{
    public GUIStyle scoreStyle;
    public GUIStyle messageStyle;
    int score;
    bool ended;

    public int AddSubScore (int delta)
    {
        score += delta;
        return score;
    }

    public void EndGame()
    {
        ended = true;
    }

    void OnGUI ()
    {
        var rect = new Rect(0, 0, Screen.width, Screen.height);

        GUI.Label (rect, "しあわせ : " + score, scoreStyle);

        if (ended) {
            GUI.Label (rect, "しゅうりょう", messageStyle);
        }
    }
}