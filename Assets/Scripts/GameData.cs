using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int MaxHp;
    public int Ammo;
    public int Damage;
    public int HighScore;
    public int SurvivalPoints;

    public float MoveSpeed;
    public float ReloadTime;
    public float FireRate;

    public int HealthPointsInvested;
    public int AmmoPointsInvested;
    public int DamagePointsInvested;
    public int MovementSpeedPointsInvested;
    public int FireRatePointsInvested;

    public GameData(int maxHp, int ammo, int damage, int highScore, int survivalPoints, float moveSpeed, float reloadTime, float fireRate, int healthPointsInvested, int ammoPointsInvested, int damagePointsInvested, int movementSpeedPointsInvested, int fireRatePointsInvested)
    {
        MaxHp = maxHp;
        Ammo = ammo;
        Damage = damage;
        HighScore = highScore;
        SurvivalPoints = survivalPoints;

        MoveSpeed = moveSpeed;
        ReloadTime = reloadTime;
        FireRate = fireRate;

        HealthPointsInvested = healthPointsInvested;
        AmmoPointsInvested = ammoPointsInvested;
        DamagePointsInvested = damagePointsInvested;
        MovementSpeedPointsInvested = movementSpeedPointsInvested;
        FireRatePointsInvested = fireRatePointsInvested;
    }
}