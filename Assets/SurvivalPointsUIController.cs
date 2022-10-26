using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurvivalPointsUIController : MonoBehaviour
{
    public TextMeshProUGUI SurvivalPointsText;
    public IntVariable SessionSurvivalPoints;

    public void UpdateSurvivalPointsText()
    {
        SurvivalPointsText.text = SessionSurvivalPoints.Value.ToString();
    }
}