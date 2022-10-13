using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject GameOverOverlay;

    public void GameOver()
    {
        GameOverOverlay.SetActive(true);
        //Time.timeScale = 0;
    }
}