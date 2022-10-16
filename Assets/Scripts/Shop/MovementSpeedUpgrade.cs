using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedUpgrade : MonoBehaviour
{
    public BuyUpgrade BuyUpgrade;
    public FloatVariable PlayerMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeMovementSpeed()
    {
        BuyUpgrade.CheckPrice();
        PlayerMovementSpeed.Value += 2f;
    }
}
