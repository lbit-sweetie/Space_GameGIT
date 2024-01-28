using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterMove : MonoBehaviour
{
    public float speed = 1;
    public float rotateSpeed = 1;


    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = speed * 0.01f;
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed / 2;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -rotateSpeed);
    }
}