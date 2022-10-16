using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: bullet object pooling
public class Shooting : MonoBehaviour
{
    public GameEvent OnReloadPrimaryWeaponEvent;
    public GameEvent OnFirePrimaryWeaponEvent;
    public GameEvent OnFinishPrimaryWeaponReloadEvent;

    [SerializeField] private IntVariable _currentAmmo;
    [SerializeField] private IntVariable _maxAmmo;
    [SerializeField] private FloatVariable _fireRate; // shots per second
    [SerializeField] private FloatVariable _reloadTime;

    private float _convertedFireRate;
    private float _currentFireTimer = 0;
    private bool _isReloading = false;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;

    private void Awake()
    {
        _currentAmmo.Value = _maxAmmo.Value;
        _convertedFireRate = 1 / _fireRate.Value;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TryShoot();
        }

        UpdateFireTimer();
    }

    public void TryReload()
    {
        if (!_isReloading)
            Reload();
    }

    private void Reload()
    {
        _isReloading = true;
        OnReloadPrimaryWeaponEvent.Raise();

        Invoke("FinishReload", _reloadTime.Value);
    }

    private void UpdateFireTimer()
    {
        if (_currentFireTimer < _convertedFireRate)
            _currentFireTimer += Time.deltaTime;
        else
            _currentFireTimer = _convertedFireRate;
    }

    public void TryShoot()
    {
        if (_currentAmmo.Value > 0 && _currentFireTimer == _convertedFireRate && !_isReloading)
            Shoot();
        else if (_currentAmmo.Value <= 0)
            TryReload();
    }

    private void Shoot()
    {
        _currentAmmo.Value -= 1;
        _currentFireTimer = 0;
        OnFirePrimaryWeaponEvent.Raise();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void FinishReload()
    {
        _currentAmmo.Value = _maxAmmo.Value;

        _isReloading = false;
        OnFinishPrimaryWeaponReloadEvent.Raise();
    }
}