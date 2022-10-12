using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Init Stats",menuName = "Statistics/Player Init Stats")]
public class PlayerInitialStats : ScriptableObject
{
    public int MaxHP;
    public float MovementSpeed;
}