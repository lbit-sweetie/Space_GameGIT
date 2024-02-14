using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterHealth : MonoBehaviour
{
    public GameObject deathParticles;

    public bool isDetected;

    private void Awake()
    {
        Destroy(gameObject, 12f);
    }

    public void TakeDamage()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);

        var a = GameObject.FindGameObjectWithTag("Player");
        a.GetComponent<PScoreSystem>().AddScore("asteroid");

        Destroy(gameObject);
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