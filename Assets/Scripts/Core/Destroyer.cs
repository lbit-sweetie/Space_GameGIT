using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.CompareTag("Asteroid") || collision.CompareTag("Platform") || 
                collision.CompareTag("Friend"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}