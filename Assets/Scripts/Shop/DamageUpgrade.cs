using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public IntVariable Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeDamage()
    {
        BuyUpgrade.CheckPrice();
        Damage.Value += 5;
    }
}
