using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterHealth : MonoBehaviour
{
    //public float health = 100;
    public PlatHealthBer healthBar;

    public bool isDetected;

    private void Awake()
    {
        Destroy(gameObject, 12f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetected = true;
            collision.gameObject.GetComponent<PHealthSystem>().TakeDamage(1);
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }
}