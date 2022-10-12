using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Preview")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private Vector2 movement;
    public int health = 100;
    private const float MAX_HEALTH = 1000;
    [SerializeField] private int _scoreValue = 1;
    public static int score = 0;
    public GameObject Score;
    private Image healthBar;

    //public GameObject deathAnimation;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerController>().transform;
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
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle + 280;
        direction.Normalize();
        movement = direction;
    }



    void MoveCharacter(Vector2 direction) {
        _rb.MovePosition((Vector2)transform.position + (direction * _moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        healthBar = GameObject.Find("BossHealth").GetComponent<Image>();
        health -= damage;

        if (gameObject.tag == "Boss")
        {
            healthBar.fillAmount = health / MAX_HEALTH;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Text myText;
        myText = GameObject.Find("Score").GetComponent<Text>();
        score += _scoreValue;

        myText.text = score.ToString() + " Points";
        Destroy(gameObject);
    }
}