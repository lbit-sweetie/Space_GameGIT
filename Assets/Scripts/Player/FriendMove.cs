using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMove : MonoBehaviour
{
    public float speed = 1;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = speed * 0.01f;
        GetComponent<Rigidbody2D>().velocity = transform.up * speed / 2;
    }
}