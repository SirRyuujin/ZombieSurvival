using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int MaxHp;
    public int Ammo;
    public int Damage;
    public int TotalScore;
    public int SurvivalPoints;

    public float MoveSpeed;
    public float ReloadTime;
    public float FireRate;

    public GameData(int maxHp, int ammo, int damage, int totalScore, int survivalPoints, float moveSpeed, float reloadTime, float fireRate)
    {
        MaxHp = maxHp;
        Ammo = ammo;
        Damage = damage;
        TotalScore = totalScore;
        SurvivalPoints = survivalPoints;

        MoveSpeed = moveSpeed;
        ReloadTime = reloadTime;
        FireRate = fireRate;
    }
}