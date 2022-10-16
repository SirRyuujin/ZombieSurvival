using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public FloatVariable FireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeFireRate()
    {
        BuyUpgrade.CheckPrice();
        FireRate.Value += 3f;
    }
}
