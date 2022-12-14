using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public IntVariable Damage;
    public SaveLoadSystem SaveLoadSystem;

    public void UpgradeDamage()
    {
        if (!BuyUpgrade.CheckPrice())
            return;

        if (SaveLoadSystem == null)
            SaveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        Damage.Value += 5;
        SaveLoadSystem.SaveData();
    }
}