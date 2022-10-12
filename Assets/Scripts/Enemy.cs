using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Preview")]
    public Transform Target;
    public float moveSpeed = 1f;
    private Vector2 movement;
    public int health = 100;
    private const float MAX_HEALTH = 1000;
    public int score_val = 1;
    public static int score = 0;
    public GameObject Score;
    private Image healthBar;

    //public GameObject deathAnimation;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        TryMoveTowardsTarget();
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void TryMoveTowardsTarget()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle + 280;
        direction.Normalize();
        movement = direction;
    }



    void MoveCharacter(Vector2 direction) {
        _rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        healthBar = GameObject.Find("BossHealth").GetComponent<Image>();
        health -= damage;

        //bossHealthBar.GetComponent<Image>().enabled = true;
        //bossHealthBar.GetComponent<Image>().fillAmount = cur_health / health;
        if (gameObject.tag == "Boss")
        {
            healthBar.fillAmount = health / MAX_HEALTH;
        }
        
        
        //bossHealthBar.fillAmount ;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //ExampleNPC.GetComponent<Animator>().Play("Zombie_death");
        Text myText;
        myText = GameObject.Find("Score").GetComponent<Text>();
        score += score_val;

        myText.text = score.ToString() + " Points";
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Wall"))
    //     {
    //         this.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
    //     }
    // }
}
