using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeeed : MonoBehaviour
{
    public float speedZubr;
    public float speedRocket;
    void Start()
    {
        GetComponent<Animator>().speed = speedZubr;
    }
}