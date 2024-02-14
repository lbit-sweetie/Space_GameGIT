using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMovement : MonoBehaviour
{
    public float speed;
    private float multiplier = 0;
    private bool isCheked = false;

    void Start()
    {
        UpdateStats();

        GetComponent<Rigidbody2D>().gravityScale = speed * 0.01f;
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed / 2;
    }

    private void UpdateStats()
    {
        isCheked = true;
        if (PlayerPrefs.HasKey("multiplierSpeedObstacles"))
        {
            multiplier = PlayerPrefs.GetInt("multiplierSpeedObstacles") * 0.1f;
        }
        else
        {
            multiplier = 1;
        }
    }

    public void AddSpeed(float addSpeed)
    {
        if (!isCheked)
        {
            UpdateStats();
        }
        speed = (speed + addSpeed) - multiplier;
    }
}