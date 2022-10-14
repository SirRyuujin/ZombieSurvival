using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInitialStats _initStats;
    [SerializeField] private LookJoystick _lookJoystick;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MoveJoystick _movementJoystick;
    [SerializeField] private Camera _cam;
    [SerializeField] private IntVariable _currentHp;
    [SerializeField] private IntVariable _maxHp;

    [Header("Events")]
    [SerializeField] private GameEvent OnChangePlayersHealthEvent;
    [SerializeField] private GameEvent OnPlayerGetHitEvent;
    [SerializeField] private GameEvent OnPlayerDieEvent;
    [SerializeField] private GameEvent OnPlayerMoveEvent;

    [Header("Preview")]
    [SerializeField] private float _playerSpeed;    
    [SerializeField] private Vector2 _mousePos;

    private void Awake()
    {
        SetInitStats();
    }

    private void FixedUpdate()
    {
        HandlePlayerCamera();
        HandlePlayerMovement();
        CalculateShootDirection();
        CalculateMousePosition();
    }

    private void SetInitStats()
    {
        _maxHp.Value = _initStats.MaxHP;
        _currentHp.Value = _maxHp.Value;
        _playerSpeed = _initStats.MovementSpeed;
    }

    private void HandlePlayerCamera()
    {
        if (_lookJoystick.joystickVec.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _lookJoystick.joystickVec);
        }
        else
            _rb.velocity = Vector2.zero;
    }

    private void HandlePlayerMovement()
    {
        if (Mathf.Abs(_movementJoystick.joystickVecMove.y) >= 0.05f)
        {
            OnPlayerMoveEvent.Raise();
            _rb.velocity = new Vector2(_movementJoystick.joystickVecMove.x * _playerSpeed, _movementJoystick.joystickVecMove.y * _playerSpeed);
        }
        else
            _rb.velocity = Vector2.zero;
    }

    private void CalculateMousePosition()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void CalculateShootDirection()
    {
        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }

    public void GetHit(int dmg)
    {
        _currentHp.Value -= dmg;

        if (_currentHp.Value <= 0)
            Die();

        OnPlayerGetHitEvent.Raise();
        OnChangePlayersHealthEvent.Raise();
    }

    private void Die()
    {
        OnPlayerDieEvent.Raise();
    }
}