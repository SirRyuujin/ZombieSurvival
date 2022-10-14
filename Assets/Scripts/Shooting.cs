using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameEvent OnReloadPrimaryWeaponEvent;
    public GameEvent OnFirePrimaryWeaponEvent;

    private float _fireRate = 2; // shots per second
    private float _convertedFireRate;
    private float _currentFireTimer = 0;
    private bool _isReloading = false;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public static int max_ammo = 30;
    public static int ammo = 30;
    private GameObject Ammo; 
    public Image reloadingCircle;
    public Image reloadingCircleProgress;
    private ReloadManually can_shoot;

    public float bulletForce = 5f;
    Text myText;

    private void Start()
    { 
        myText = GameObject.Find("Ammo").GetComponent<Text>();
        _convertedFireRate = 1 / _fireRate;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0 && _currentFireTimer == _convertedFireRate && ReloadManually.can_shoot == true)
            {
                Shoot();
                ammo -= 1;
                myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;
            }
            else if(ammo <= 0 && !_isReloading)
            { 
                Reload();
            }    
        }

        if (_currentFireTimer < _convertedFireRate)
            _currentFireTimer += Time.deltaTime;
        else
            _currentFireTimer = _convertedFireRate;
    }

    private void Shoot()
    {
        OnFirePrimaryWeaponEvent.Raise();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        _isReloading = true;
        reloadingCircle.enabled = true;
        reloadingCircleProgress.enabled = true;
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
        OnReloadPrimaryWeaponEvent.Raise();

        // reloadingCircle.enabled = false;
        // reloadingCircleProgress.enabled = false;
        // ammo = max_ammo;
        // myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;

        Invoke("ExecuteAfterTime", 2.5f);
    }

    private void ExecuteAfterTime()
    {
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
    
        reloadingCircle.enabled = false;
        reloadingCircleProgress.enabled = false;
        ammo = max_ammo;
        myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;

        _isReloading = false;
    }
}