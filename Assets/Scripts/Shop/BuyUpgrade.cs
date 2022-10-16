using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    public IntVariable CurrentScore;
    public IntVariable Price;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckPrice()
    {
        if (CurrentScore.Value >= Price.Value)
        {
            Debug.Log("Sold!");
            CurrentScore.Value -= Price.Value;
            return true;
            
        }
        else 
        {
            Debug.Log("You don't have enough points!");
            return false;
        }
    }
}
