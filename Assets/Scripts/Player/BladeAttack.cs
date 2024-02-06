using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAttack : MonoBehaviour
{
    public float damage;
    private AwardsSystem awardSystem;

    private void Start()
    {
        awardSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<AwardsSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Asteroid":
                ColisionAsteroid(collision);
                break;
            case "Platform":
                ColisionPlatform(collision);
                break;
            case "Award":
                awardSystem.GetTypeAward(collision.gameObject.name);
                Destroy(collision.gameObject);
                break;
        }
    }

    private void ColisionPlatform(Collider2D col)
    {
        col.GetComponent<PlatHealth>().TakeDamage(damage);
    }

    private void ColisionAsteroid(Collider2D col)
    {
        col.GetComponent<AsterHealth>().TakeDamage();
    }
}