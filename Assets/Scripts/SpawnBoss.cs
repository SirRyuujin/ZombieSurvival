using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{

    public GameObject boss; 
    public Image bossHealthBarBG;
    public Image bossHealthBar;
    public Image Skull;
    private bool noBoss = true;
    private const float MAX_HEALTH = 100f;
    public float health = MAX_HEALTH;
    private Image healthBar;
    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        bossHealthBar.enabled = false;
        bossHealthBarBG.enabled = false;
        Skull.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Enemy.score == 1 && noBoss == true)
        //    {
        //       noBoss = false;
        //       SpawnBossFunc();
        //       bossHealthBar.enabled = true;
        //       bossHealthBarBG.enabled = true;
        //       Skull.enabled = true;
        //    }
        //if (bossHealthBar.fillAmount == 0)
        //{
        //    bossHealthBar.enabled = false;
        //    bossHealthBarBG.enabled = false;
        //    Skull.enabled = false; 
        //}
    }

    //public void SpawnBossFunc()
    // {
    //     spawner.spawnPosition.x = Random.Range (0, 15);
    //     spawner.spawnPosition.y = 0.5f;
    //     spawner.spawnPosition.z = Random.Range (0, 15);

    //     Instantiate(boss, spawner.spawnPosition, Quaternion.identity);
    // }
}
