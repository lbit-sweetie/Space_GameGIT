using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardChangeWeapon : MonoBehaviour
{
    public string nameWeapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PAttack>().ChangeWeapon(nameWeapon);
        }
    }
}