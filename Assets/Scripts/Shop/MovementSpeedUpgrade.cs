using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public FloatVariable PlayerMovementSpeed;
    public SaveLoadSystem SaveLoadSystem;

    public void UpgradeMovementSpeed()
    {
        if (!BuyUpgrade.CheckPrice())
            return;

        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        PlayerMovementSpeed.Value += 0.1f;
        SaveLoadSystem.SaveData();
    }
}