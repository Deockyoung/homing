using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_boss_path_manager : MonoBehaviour {

    //보스 패스는 일정 거리를 유지하면서 플레이어를 쳐다 본다

    Transform player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").GetComponent<Transform>();

    }
	
	void Update () {
		
        
	}
}
