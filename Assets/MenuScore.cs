using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    public GameEvent OnChangeScoreEvent;
    public IntVariable Score;
    public IntVariable CurrentScore;
    public TextMeshProUGUI CounterText;

    void FixedUpdate()
    {
        UpdateCounterText();
    }

    public void UpdateCounterText()
    {
        Score.Value += CurrentScore.Value;
        CurrentScore.Value = 0;
        CounterText.text = Score.Value.ToString();
    }

            
}
