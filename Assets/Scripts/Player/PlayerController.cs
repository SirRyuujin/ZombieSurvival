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

    [Header("Events")]
    [SerializeField] private GameEvent OnChangePlayersHealthEvent;

    [Header("Preview")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Vector2 _mousePos;
    public int CurrentHealth { get; private set; }
    [SerializeField] private int _maxHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            // get enemy dmg
            GetHit(1);
        }
    }

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
        _maxHealth = _initStats.MaxHP;
        CurrentHealth = _maxHealth;
        _playerSpeed = _initStats.MovementSpeed;
    }

    private void HandlePlayerCamera()
    {
        if (_lookJoystick.joystickVec.y != 0)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _lookJoystick.joystickVec);
        else
            _rb.velocity = Vector2.zero;
    }

    private void HandlePlayerMovement()
    {
        if (_movementJoystick.joystickVecMove.y != 0)
            _rb.velocity = new Vector2(_movementJoystick.joystickVecMove.x * _playerSpeed, _movementJoystick.joystickVecMove.y * _playerSpeed);
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

    private void GetHit(int dmg)
    {
        CurrentHealth -= dmg;

        if (CurrentHealth <= 0)
            Die();

        OnChangePlayersHealthEvent.Raise();
    }

    private void Die()
    {
        Debug.Log("I Just Died");
    }
}