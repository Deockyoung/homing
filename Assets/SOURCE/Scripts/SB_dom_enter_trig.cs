using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_dom_enter_trig : MonoBehaviour {

    public  SB_bossManager boss_scr;
    bool is_player_enter = false;
    Transform player;
    Transform player_start_pos;
    Vector3 dir;
    bool imsi = false;
    public float moveSpeed = 10f; 
	// Use this for initialization
	void Start () {
      
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {


        if(is_player_enter== true && imsi == false)
        {
            dir = player_start_pos.position - player.position;
            if(Vector3.Distance(player_start_pos.position, player.position)>10f)
            {
                //player.position +=  dir.normalized * moveSpeed;
            }

            else if(Vector3.Distance(player_start_pos.position,player.position)<=10f)
            {
                //이동 끝 
                //player.position = player_start_pos.position;

                imsi = true;
                boss_scr = transform.parent.GetChild(2).GetComponent<SB_bossManager>();
                boss_scr.mState = SB_bossManager.BossState.Idle;

                is_player_enter = false;

            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            print("돔구간 시작으로 속도 저하 ");
            player_start_pos = transform.GetChild(0).GetComponent<Transform>();
            HandController.maxSpeed = 1;
            is_player_enter = true;
        }
    }

}
