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
        


        //Vector3 rotation = new Vector3(Input.acceleration.x, 0f, 0f);
        //transform.position = new Vector3(transform.position.x + rotation.x * speedOfMove * 0.3f,
        //    transform.position.y, transform.position.z);
        //if (transform.position.x >= tempXRight && transform.position.x > 0)
        //{
        //    var a = new Vector3(tempXRight, transform.position.y, 0);
        //    transform.position = a;
        //    return;
        //}
        //else
        //{
        //    if (transform.position.x <= tempXLeft && transform.position.x < 0)
        //    {
        //        var b = new Vector3(tempXLeft, transform.position.y, 0);
        //        transform.position = b;
        //        return;
        //    }
        //}
    }
}
