using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatHealth : MonoBehaviour
{
    [Header("Stats")]
    public ParticleSystem takeDamageParticle;
    public GameObject explosionPref;
    public PlatHealthBer healthBar;
    [Header("Stats")]
    public float health = 100;
    public int amountOfHealth;
    [SerializeField] private string typePlatform = "usual";
    public bool isDetected;

    private float currentVelocity;
    private float damageBlade;


    private void Awake()
    {
        Destroy(gameObject, 12f);
    }
    private void Start()
    {
        damageBlade = GameObject.FindGameObjectWithTag("Blade").GetComponent<BladeAttack>().damage;
        healthBar.SetMaxHealth(Convert.ToInt32(health));
    }

    public void AddHealth(float amount)
    {
        health += amount;
        healthBar.SetMaxHealth(Convert.ToInt32(health));
    }
    public void TakeDamage(float amout)
    {
        Instantiate(takeDamageParticle, transform.position, Quaternion.identity);

        health -= amout;

        if (health <= 0)
        {
            Death();
        }
    }

    private void Update()
    {
        float currentHealth = Mathf.SmoothDamp(healthBar.GetComponent<PlatHealthBer>().slider.value,
            health, ref currentVelocity, 50f * Time.deltaTime);
        healthBar.SetHealth(Convert.ToInt32(currentHealth));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDetected)
        {
            if (collision.CompareTag("Player"))
            {
                isDetected = true;
                collision.gameObject.GetComponent<PHealthSystem>().TakeDamage(amountOfHealth);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Blade"))
            {
                isDetected = true;
                TakeDamage(damageBlade);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            isDetected = false;
        }
    }

    public void Death()
    {
        var a = GameObject.FindGameObjectWithTag("Player");
        a.GetComponent<PScoreSystem>().AddScore(typePlatform);

        var b = Instantiate(explosionPref, gameObject.transform.position, Quaternion.identity);
        Destroy(b, 1);

        Destroy(gameObject);

    }
}