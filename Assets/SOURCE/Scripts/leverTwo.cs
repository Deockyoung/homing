using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverTwo : MonoBehaviour {
    public static bool leverTwoEnter;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            leverTwoEnter = true;
            print("2222");
        }
    }
}
