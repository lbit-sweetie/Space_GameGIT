using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    private Vector2 offset = Vector2.zero;
    public float speed = 0.1f;
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        offset.y += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
