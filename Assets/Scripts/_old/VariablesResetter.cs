#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class VariablesResetter : MonoBehaviour
{
    public IntVariable HighScore;
    public IntVariable SurvivalPoints;
    public IntVariable PlayerMaxHp;
    public IntVariable PlayerDamage;
    public IntVariable PlayerMaxAmmo;

    public FloatVariable PlayerMovementSpeed;
    public FloatVariable PlayerFireRate;
    public FloatVariable PlayerReloadTime;

    public IntVariable HealthPointsInvested;
    public IntVariable AmmoPointsInvested;
    public IntVariable DamagePointsInvested;
    public IntVariable MovementSpeedPointsInvested;
    public IntVariable FireRatePointsInvested;

    public BoolVariable IsGamePaused;

    public void ResetVaraiblesToDefaultValues()
    {
        HighScore.Value = 0;
        SurvivalPoints.Value = 0;
        PlayerMaxHp.Value = 100;
        PlayerDamage.Value = 40;
        PlayerMaxAmmo.Value = 10;

        PlayerMovementSpeed.Value = 2;
        PlayerFireRate.Value = 1;
        PlayerReloadTime.Value = 3;

        HealthPointsInvested.Value = 0;
        AmmoPointsInvested.Value = 0;
        DamagePointsInvested.Value = 0;
        MovementSpeedPointsInvested.Value = 0;
        FireRatePointsInvested.Value = 0;

        IsGamePaused.Value = false;
    }
}
#endif