using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public float tempXLeft;
    public float tempXRight;

    public float speedOfMove;

    public void CheckNeed()
    {
        if (PlayerPrefs.HasKey("isNeedAcs"))
        {
            if (PlayerPrefs.GetString("isNeedAcs") == "no")
            {
                var scr = GetComponent<PMovement>();
                if (scr)
                    Destroy(scr);
            }
        }
        else
        {
            var scr = GetComponent<PMovement>();
            if (scr)
                Destroy(scr);
        }
    }

    private void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * speedOfMove, tempXRight - tempXLeft) + tempXLeft;
        Vector3 newPosition = new Vector3(pingPongValue, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}