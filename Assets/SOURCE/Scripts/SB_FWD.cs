using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_FWD : MonoBehaviour {

    TrailRenderer tr;
	// Use this for initialization
	void Start () {
        tr = transform.GetComponentInParent<TrailRenderer>();
        tr.Clear();
	}
	
	// Update is called once per frame
	void Update () {

        transform.forward = transform.parent.forward;
	}
}
