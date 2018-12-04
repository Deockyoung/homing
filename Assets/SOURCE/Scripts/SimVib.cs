using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimVib : MonoBehaviour {
    HandController hc;
    // Use this for initialization
    void Start () {
         hc = GameObject.Find("Player").GetComponent<HandController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameObject.Find("Player").GetComponent<HandController>().vibsum = 0;
            
            hc.StartCoroutine("CoSimulVib");


        }


    }
}
