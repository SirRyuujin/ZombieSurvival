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
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private EnemyBaseStats _baseStats;

    [Header("Preview")]
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private PlayerController _target;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _currentHp;
    public int Damage { get; private set; }

    private int _maxHp;
    private float _attackCooldown;
    [SerializeField] private float _timeLeftToAttack = 0;
    private float _attackRange;
    private Vector2 _movement;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerController>();
        if (_target != null)
            _targetTransform = _target.transform;

        SetInitStats();
    }

    private void Update()
    {
        TryMoveTowardsTarget();

        TryAttack();
    }

    private void FixedUpdate()
    {
        MoveCharacter(_movement);
    }

    private void TryAttack()
    {
        if (_timeLeftToAttack == 0 && Vector2.Distance(_targetTransform.position, transform.position) <= _attackRange)
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
        _moveSpeed = _baseStats.MovementSpeed;
        _attackCooldown = _baseStats.AttackCooldown;
        _attackRange = _baseStats.AttackRange;
        Damage = _baseStats.Damage;
    }

    private void TryMoveTowardsTarget()
    {
        if (_targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _targetTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle + 280;
        direction.Normalize();
        _movement = direction;
    }

    private void MoveCharacter(Vector2 direction)
    {
        _rb.MovePosition((Vector2)transform.position + (direction * _moveSpeed * Time.deltaTime));
    }
  
    private void Die()
    {
        OnEnemyDieEvent.Raise();
        OnNormalZombieDieEvent.Raise();
        Destroy(gameObject);
    }
}