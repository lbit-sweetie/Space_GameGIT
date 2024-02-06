using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PHealthSystem>().Death(true);
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 20f);
    }
}