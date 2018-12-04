using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_SLOW : MonoBehaviour
{

    //돌 움직임 리얼리티 있게 제어할것 

    public float movespeed =0.5f;
    public  Transform target;
    Rigidbody rd;
    Vector3 dir;
    public bool istest = false;
    // Use this for initialization
    void Start()
    {

        rd = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        dir = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (istest)
        {
            rd.velocity = dir * movespeed *-1;
        }

    }

}

