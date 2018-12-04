using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_skill1 : MonoBehaviour {

    public bool is_active = false;
    ParticleSystem ps;
    public bool isrotate = false;

	// Use this for initialization
	void Start () {
        //ps = GameObject.Find("skillAttack2").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.R))
        {
            is_active = true;
            ps.Stop();
            ps.Play();

        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            is_active = false;
        }

        if(is_active)
        {
           
        }
        if(isrotate)
        {
            transform.Rotate(Vector3.up);
        }
   
	}
}
