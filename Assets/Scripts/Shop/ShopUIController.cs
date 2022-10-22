using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    public TextMeshProUGUI SurvivalPointsText;
    public IntVariable SurvivalPoints;

    private void Awake()
    {
        UpdateSurvivalPointsText();
    }

    public void UpdateSurvivalPointsText()
    {
        SurvivalPointsText.text = SurvivalPoints.ToString();
    }
}