using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent OnEnemyDieEvent;
    [SerializeField] private GameEvent OnNormalZombieDieEvent;

    [Header("References")]
    public Rigidbody2D Rb;
    [SerializeField] private EnemyBaseStats _baseStats;

    [Header("Preview")]
    public Transform TargetTransform; // SO reference?
    [SerializeField] private PlayerController _target;
    public float MoveSpeed = 1f;
    [SerializeField] private int _currentHp;
    [SerializeField] private float _timeLeftToAttack = 0;
    public int Damage { get; private set; }

    private int _maxHp;
    private float _attackCooldown;
    private float _attackRange;
    private Vector2 _movement;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerController>();
        if (_target != null)
            TargetTransform = _target.transform;

        SetInitStats();
    }

    private void Update()
    {
        TryAttack();
    }

    private void TryAttack()
    {
        //Debug.DrawLine(_targetTransform.position, transform.position);
        //Debug.Log(Vector2.Distance(_targetTransform.position, transform.position));
        if (_timeLeftToAttack == 0 && Vector2.Distance(TargetTransform.position, transform.position) <= _attackRange)
        {
            _target.GetHit(Damage); // event based?
            StartCoroutine(ResetAttackTimerCoroutine());
        }
    }

    private IEnumerator ResetAttackTimerCoroutine()
    {
        _timeLeftToAttack = _attackCooldown;
        while (_timeLeftToAttack > 0)
        {
            _timeLeftToAttack -= Time.deltaTime;
            yield return null;
        }

        _timeLeftToAttack = 0;
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
            Die();
    }

    private void SetInitStats()
    {
        _maxHp = _baseStats.MaxHP;
        _currentHp = _maxHp;
        MoveSpeed = _baseStats.MovementSpeed;
        _attackCooldown = _baseStats.AttackCooldown;
        _attackRange = _baseStats.AttackRange;
        Damage = _baseStats.Damage;
    }

    private void TryMoveTowardsTarget()
    {
        if (TargetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = TargetTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Rb.rotation = angle + 280;
        direction.Normalize();
        _movement = direction;
    }

    private void MoveCharacter(Vector2 direction)
    {
        Rb.MovePosition((Vector2)transform.position + (direction * MoveSpeed * Time.deltaTime));
    }
  
    private void Die()
    {
        OnEnemyDieEvent.Raise();
        OnNormalZombieDieEvent.Raise();
        Destroy(gameObject);
    }
}