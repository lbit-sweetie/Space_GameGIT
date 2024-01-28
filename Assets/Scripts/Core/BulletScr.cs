using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    public float _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            other.GetComponent<PlatHealth>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 1.5f);
    }
}
