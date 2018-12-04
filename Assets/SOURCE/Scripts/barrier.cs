using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour {
    HandController hc;
    // Use this for initialization
    void Start () {
        hc = GameObject.Find("Player").GetComponent<HandController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerTrigger")
        {
            print("barrier!!!");
            GameObject.Find("Player").GetComponent<HandController>().vibsum = 0;

            hc.StartCoroutine("CoSimulVib");
            GameObject.Find("Player").GetComponent<HandController>().Damage();

        }
    }
}
