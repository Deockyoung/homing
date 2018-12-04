using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendForward : MonoBehaviour {
    public float friendSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * friendSpeed * Time.deltaTime;
	}
}
