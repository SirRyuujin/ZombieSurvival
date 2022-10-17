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
        BuyUpgrade.CheckPrice();
        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        FireRate.Value += 3f;
        SaveLoadSystem.SaveData();
    }
}