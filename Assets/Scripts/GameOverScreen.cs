using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup()
    {
        gameObject.SetActive(true);
        Text myText;
        myText = GameObject.Find("Score").GetComponent<Text>();
        pointsText.text = myText.text;
    }
        
}
