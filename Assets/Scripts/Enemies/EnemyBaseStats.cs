using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Statistics/Enemy Base Stats")]
public class EnemyBaseStats : ScriptableObject
{
    public float MovementSpeed;
    public int MaxHP;
    public int Score;
    public int Damage;
    public float AttackCooldown;
    public float AttackRange;
}