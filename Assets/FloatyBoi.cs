using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloatyBoi : MonoBehaviour
{
    private float movementSpeed = 0.04f;
    public float x;
    public float y;
    private double radius;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float theta = (Time.fixedTime % 180) * 2;
        radius = Math.Cos(theta * 3);
        x = (float)(radius * Math.Cos(theta));
        y = (float)(radius * Math.Sin(theta));

        //update the position
        transform.position = transform.position + new Vector3(y * movementSpeed, x * movementSpeed, 0);

    }
}
