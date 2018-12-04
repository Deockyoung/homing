using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_DoorM : MonoBehaviour {

    Animator anim;
    Transform target;
    public float closeDistance = 100;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        target = GameObject.Find("target_pos").GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Vector3.Distance(target.position,transform.position)<=closeDistance)
        {

            anim.SetTrigger("close");
        }
	}
}
