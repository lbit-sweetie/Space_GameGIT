using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterMove : MonoBehaviour
{
    public float speed = 1;
    public float rotateSpeed = 1;
    private float multiplier = 1;


    void Start()
    {
        UpdateStats();
        GetComponent<Rigidbody2D>().gravityScale = speed * 0.01f;
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed / 2;
    }

    private void UpdateStats()
    {
        if (PlayerPrefs.HasKey("multiplierSpeedObstacles"))
        {
            multiplier = PlayerPrefs.GetInt("multiplierSpeedObstacles") * 0.5f;
        }
        else
        {
            multiplier = 1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -rotateSpeed);
    }

    public void AddSpeed(float amout)
    {
        speed = (speed + amout) - multiplier;
        rotateSpeed += amout / 2;
    }
}
