using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject impactEffect;
    public IntVariable PlayerDamage;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(PlayerDamage.Value);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 10f);
    }
}