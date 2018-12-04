using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSFlight : MonoBehaviour {
    GameObject player;

    Vector3 dir;
    public float speed= 10;
    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");
        dir = player.transform.position-transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        //dir = player.transform.position - transform.position;
        transform.LookAt(player.transform);
       
        //transform.Translate(dir  * speed * Time.deltaTime);
    }
}
