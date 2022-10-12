using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollisionDestroy : MonoBehaviour
{
    public GameObject player;
    private Image healthBar;
    private const float MAX_HEALTH = 100;
    public float health = MAX_HEALTH;
    public Spawner gameController;
    
    void OnCollisionEnter2D (Collision2D hit)
    {
      if(hit.gameObject.tag == "Enemy")
      {
           healthBar = GameObject.Find("Health").GetComponent<Image>();
           health -= 10;
           healthBar.fillAmount = health / MAX_HEALTH;
           
           if(health == 0)
           {
            Destroy(player);
            gameController.GameOver();
           } 
      }
    }
}
