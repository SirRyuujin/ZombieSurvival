using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public IntVariable PlayerHealth;
    public SaveLoadSystem SaveLoadSystem;

    public void UpgradeMaxHP()
    {
        if (!BuyUpgrade.CheckPrice())
            return;

        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();
        
        PlayerHealth.Value += 20;
        SaveLoadSystem.SaveData();
    }
}