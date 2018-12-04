﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        {
            ChangeMode.ShootingMode = false;
        }
    }

}