using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public GameEvent OnChangeScoreEvent;
    public IntVariable Score;
    public TextMeshProUGUI CounterText;

    void FixedUpdate()
    {
        UpdateCounterText();
    }

    public void UpdateCounterText()
    {
        CounterText.text = Score.Value.ToString();
    }
}