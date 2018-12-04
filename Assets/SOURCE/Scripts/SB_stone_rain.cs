using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_stone_rain : MonoBehaviour {

    //돌 움직임 리얼리티 있게 제어할것 

    public float movespeed ;
    public Transform target;
    Rigidbody rd;
    Vector3 dir;
    float add = 0.5f;
    public bool isfall = false;
    float curtime;
	// Use this for initialization
	void Start () {

        rd = GetComponent<Rigidbody>();
       // target = transform.parent.GetChild(0).transform;
        target = GameObject.Find("target_pos").GetComponent<Transform>();
        dir = transform.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {

     

        if (isfall)
        {
            curtime += Time.deltaTime;
            add++;
            rd.AddForce(new Vector3(dir.x,dir.y,dir.z).normalized *(movespeed+ add) *-1 , ForceMode.Acceleration);
            if(curtime> 15)
            {
                gameObject.SetActive(false);
            }
        }

	}

}
