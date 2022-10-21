using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public IntVariable PlayerMaxAmmo;
    public SaveLoadSystem SaveLoadSystem;

    public void UpgradeMaxAmmo()
    {
        if (!BuyUpgrade.CheckPrice())
            return;

        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        PlayerMaxAmmo.Value += 1;
        SaveLoadSystem.SaveData();
    } 
}