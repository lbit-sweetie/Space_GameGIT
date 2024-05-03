using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAttack : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        GetSavedStats();
    }

    private void GetSavedStats()
    {
        if (PlayerPrefs.HasKey("multiplierDamage"))
        {
            damage += PlayerPrefs.GetInt("multiplierDamage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Asteroid":
                ColisionAsteroid(collision);
                break;
            case "Award":
                Destroy(collision.gameObject);
                break;
        }
    }

    private void ColisionAsteroid(Collider2D col)
    {
        col.GetComponent<AsterHealth>().TakeDamage();
    }
}