using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    //private bool drag;

    public float tempXLeft;
    public float tempXRight;

    public float speedOfMove;

    //private void OnMouseDown()
    //{
    //    drag = true;
    //}

    //private void OnMouseUp()
    //{
    //    drag = false;
    //}


    private void FixedUpdate()
    {
        //if (drag)
        //{
        //if (!gameObject.CompareTag("Player"))
        //{
        //Vector2 mousePos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        //transform.parent.Translate(mousePos1 - new Vector2(0, 0.6f));

        Vector3 rotation = new Vector3(Input.acceleration.x, 0f, 0f);
        //Debug.Log(rotation);
        //transform.Translate(new Vector3(transform.position.x + rotation.x, 0, 0));
        transform.position = new Vector3(transform.position.x + rotation.x * speedOfMove * 0.3f,
            transform.position.y, transform.position.z);

        if (transform.position.x >= tempXRight && transform.position.x > 0)
        {
            //Debug.Log(transform.position.y);
            var a = new Vector3(tempXRight, transform.position.y, 0);
            transform.position = a;
            return;
        }
        else
        {
            if (transform.position.x <= tempXLeft && transform.position.x < 0)
            {
                var b = new Vector3(tempXLeft, transform.position.y, 0);
                transform.position = b;
                return;
            }
        }
        //}
        //else
        //{
        //    //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //    //transform.Translate(mousePos - new Vector2(0, 0.6f));

        //    Vector3 rotation = new Vector3(Input.acceleration.x, 0, 0);
        //    Debug.Log(rotation);
        //    transform.Translate(transform.position + rotation);

        //    if (transform.position.x >= tempXRight && transform.position.x > 0)
        //    {
        //        var a = new Vector2(tempXRight, transform.position.y);
        //        transform.position = a;
        //        return;
        //    }
        //    else
        //    {
        //        if (transform.position.x <= tempXLeft && transform.position.x < 0)
        //        {
        //            var b = new Vector2(tempXLeft, transform.position.y);
        //            transform.position = b;
        //            return;
        //        }
        //    }
        //}
        //}
    }
}
