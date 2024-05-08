using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasdasldGGGG : MonoBehaviour
{
    private Vector2 offset = Vector2.zero;
    public float speed = 0.1f;
    private Material material;

    private bool _switch = false;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        if (_switch)
        {
            offset.x += speed * Time.deltaTime;
        }
        else
        {
            offset.x -= speed * Time.deltaTime;
        }
        material.SetTextureOffset("_MainTex", offset);

        if (offset.x >= 0.19f)
        {
            _switch = false;
        }
        else
        {
            if (offset.x <= -0.19f)
            {
                _switch = true;
            }
        }
    }
}
