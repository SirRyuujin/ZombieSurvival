using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
      public GameObject enemy;                // The prefab to be spawned.
      public float spawnTime = 3f;            // How long between each spawn.
      public Vector3 spawnPosition;
      public GameOverScreen GameOverScreen;
      private static int gameOver = 0;
      
     public void GameOver() 
     {
        gameOver = 1;
        GameOverScreen.Setup();
     }
 
     // Use this for initialization
     void Start () 
     {
        //  QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 60;
         // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
         
         
         InvokeRepeating ("Spawn", spawnTime, spawnTime);
     }

     void Update()
     {
         
     }
 
     void Spawn ()
     {
        if (gameOver == 0)
        {
            spawnPosition.x = Random.Range (0, 15);
            spawnPosition.y = 0.5f;
            spawnPosition.z = Random.Range (0, 15);
    
            Instantiate(enemy, spawnPosition, Quaternion.identity);

            
        } 
         
     }

     
}
