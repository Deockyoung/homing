using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_droneEnemy : MonoBehaviour {

    // Use this for initialization
    //처음 생성되면 플레이어를 향해 돌진한다.
    //정해진 시간 마다 총알을 쏜다. 
    Transform target;
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
