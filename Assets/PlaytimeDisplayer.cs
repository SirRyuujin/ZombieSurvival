using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaytimeDisplayer : MonoBehaviour
{
    public FloatVariable Playtime;
    public BoolVariable IsGamePaused;
    public TextMeshProUGUI MessageBox;
    public float Seconds = 0;
    public int Minutes = 0;
    public int Hours = 0;

    private void Update()
    {
        ParseData();
        DisplayMessage();
    }

    private void ParseData()
    {
        if (Playtime.Value >= 3600)
            Hours = (int)Playtime.Value / 3600;
        Minutes = (int)(Playtime.Value - (3600 * Hours)) / 60;
        Seconds = (Playtime.Value - (60 * Minutes) - (3600 * Hours));
    }

    private void DisplayMessage()
    {
        if (Hours > 0)
            MessageBox.text = string.Format("{0:0}:{1:00}:{2:0}", Hours, Minutes, Seconds);
        else if (Minutes > 0)
            MessageBox.text = string.Format("{0:0}:{1:00}", Minutes, Seconds);
        else
            MessageBox.text = string.Format("{0:0}", Seconds);
    }
}