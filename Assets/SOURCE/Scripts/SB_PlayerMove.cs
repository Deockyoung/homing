using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_PlayerMove : MonoBehaviour {

    Rigidbody rd;
    CharacterController cc;
	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.W))
        {
            cc.Move(transform.forward  );
        }
        if(Input.GetKey(KeyCode.A))
        {
            cc.Move(transform.right*-1 );
        }

        if (Input.GetKey(KeyCode.D))
        {
            cc.Move(transform.right );
        }

        if (Input.GetKey(KeyCode.S))
        {
            cc.Move(transform.forward * -1);
        }
	}
}
