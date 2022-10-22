using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    public IntVariable SurvivalPoints;
    public IntVariable PointsInvested;
    public TextMeshProUGUI PriceText;
    public GameEvent OnSurvivalPointsSpentEvent;

    private void Awake()
    {
        SetPriceText();
    }

    private int GetPrice(int lvl)
    {
        if (lvl == 0)
            return 1;
        else if (lvl == 1)
            return 2;
        else
            return (5 * (lvl - 1));
    }

    public bool CheckPrice()
    {
        if (SurvivalPoints.Value >= GetPrice(PointsInvested.Value))
        {
            Debug.Log("Sold!");
            SurvivalPoints.Value -= GetPrice(PointsInvested.Value);
            PointsInvested.Value++;
            SetPriceText();
            OnSurvivalPointsSpentEvent.Raise();
            return true;            
        }
        else 
        {
            Debug.Log("You don't have enough points!");
            return false;
        }
    }

    public void SetPriceText()
    {
        PriceText.text = GetPrice(PointsInvested.Value).ToString();
    }
}