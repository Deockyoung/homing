using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_StormStuff : MonoBehaviour {

   public Transform rotateCenter;
    // Use this for initialization
    public float rotSpeed = 50;
    float x =0.2f;
    float y;
    float z = 0.1f;

	void Start () {
        rotateCenter = transform.parent.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

         y = Random.Range(0.1f, 10.2f);
        transform.RotateAround(rotateCenter.position, new Vector3(x, y,z), rotSpeed* Time.deltaTime);
	}
}
