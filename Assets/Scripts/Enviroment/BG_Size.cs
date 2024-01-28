using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Size : MonoBehaviour
{
    private void Start()
    {
        var height = Camera.main.orthographicSize * 3f;
        var width = height * Screen.width / Screen.height * 1.5f;

        transform.localScale = new Vector3(width, height, 0);
    }
}
