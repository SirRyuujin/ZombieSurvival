using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public IntVariable PlayerMaxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeMaxAmmo()
    {
        BuyUpgrade.CheckPrice();
        PlayerMaxAmmo.Value += 5;
    }

    
}
