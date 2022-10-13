using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public GameEvent OnChangeScoreEvent;
    public IntVariable Score;
    public TextMeshProUGUI CounterText;

    public void UpdateCounterText()
    {
        CounterText.text = Score.Value.ToString();
    }
}