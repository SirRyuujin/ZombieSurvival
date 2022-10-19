using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesResetter : MonoBehaviour
{
    public IntVariable TotalScore;
    public IntVariable SurvivalPoints;
    public IntVariable PlayerMaxHp;
    public IntVariable PlayerDamage;
    public IntVariable PlayerMaxAmmo;

    public FloatVariable PlayerMovementSpeed;
    public FloatVariable PlayerFireRate;
    public FloatVariable PlayerReloadTime;

    public void ResetVaraiblesToDefaultValues()
    {
        TotalScore.Value = 0;
        SurvivalPoints.Value = 0;
        PlayerMaxHp.Value = 100;
        PlayerDamage.Value = 40;
        PlayerMaxAmmo.Value = 10;

        PlayerMovementSpeed.Value = 2;
        PlayerFireRate.Value = 1;
        PlayerReloadTime.Value = 3;
    }
}