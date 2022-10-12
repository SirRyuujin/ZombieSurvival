using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static int max_ammo = 30;
    public static int ammo = 30;
    private GameObject Ammo; 
    public Image reloadingCircle;
    public Image reloadingCircleProgress;
    private ReloadManually can_shoot;

    public float bulletForce = 5f;

    // Update is called once per frame
    void Update()
    {
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();

        if(Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0 && ReloadManually.can_shoot == true)
            {
                Shoot();
                ammo -= 1;
                myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;
            }
            else if(ammo <= 0)
            { 
                Reload();
            }
            
            
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }

    public void Reload()
    {
        reloadingCircle.enabled = true;
        reloadingCircleProgress.enabled = true;
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
        
    
        // reloadingCircle.enabled = false;
        // reloadingCircleProgress.enabled = false;
        // ammo = max_ammo;
        // myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;
                
        Invoke("ExecuteAfterTime", 2.5f);
    }

    void ExecuteAfterTime()
    {
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
    
        reloadingCircle.enabled = false;
        reloadingCircleProgress.enabled = false;
        ammo = max_ammo;
        myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;
    
    }
}
