using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour
{
    public GUIStyle labelStyle;
    int score;

    public int AddSubScore (int delta)
    {
        score += delta;
        return score;
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (32, 32, Screen.width - 64, Screen.height - 64), "しあわせ : " + score, labelStyle);
    }
}