using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStart : MonoBehaviour {

    public static bool handle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //other.transform.tag == "Player"  // other.gameObject.layer == LayerMask.NameToLayer("Player")
        if (other.transform.tag == "Player")
            {

            print("플레이어 인트로 끝?");
            leverTwo.leverTwoEnter = false;
            handle = true;
        }
    }
}
