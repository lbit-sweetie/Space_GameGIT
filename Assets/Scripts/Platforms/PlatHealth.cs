using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatHealth : MonoBehaviour
{
    public GameObject explosionPref;
    public PlatHealthBer healthBar;
    [Header("Stats")]
    public float health = 100;
    public int amountOfHealth;
    [SerializeField] private string typePlatform = "usual";

    public bool isDetected;


    private void Awake()
    {
        Destroy(gameObject, 12f);
    }
    private void Start()
    {
        healthBar.SetMaxHealth(Convert.ToInt32(health));
    }
    public void TakeDamage(float amout)
    {
        health -= amout;
        healthBar.SetHealth(Convert.ToInt32(health));
        if (health <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDetected)
        {
            if (collision.CompareTag("Player"))
            {
                isDetected = true;
                collision.gameObject.GetComponent<PHealthSystem>().TakeDamage(amountOfHealth);
                gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
        }
    }

    public void Death()
    {
        if (!isDetected)
        {
            var a = GameObject.FindGameObjectWithTag("Player");
            a.GetComponent<PScoreSystem>().AddScore(typePlatform);
            a.GetComponent<AwardsSystem>().GetAward(gameObject.transform.position, isDetected);

            var b = Instantiate(explosionPref, gameObject.transform.position, Quaternion.identity);
            Destroy(b, 1);

            Destroy(gameObject);
        }
    }
}
