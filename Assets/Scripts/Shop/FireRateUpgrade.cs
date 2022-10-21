using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public FloatVariable FireRate;
    public SaveLoadSystem SaveLoadSystem;

    public void UpgradeFireRate()
    {
        if (!BuyUpgrade.CheckPrice())
            return;

        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        FireRate.Value += 0.5f;
        SaveLoadSystem.SaveData();
    }
}