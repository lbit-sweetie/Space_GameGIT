using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            if (!collision.GetComponent<PlatHealth>().isDetected)
            {
                collision.GetComponent<PlatHealth>().Death();
                collision.GetComponent<PlatHealth>().isDetected = true;
                gameObject.SetActive(false); 
            }
        }
    }
}