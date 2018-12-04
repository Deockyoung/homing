using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_asteroid_exp : MonoBehaviour {

    Rigidbody[] RD;
    Transform exp_pos;
    public float exp_force = 4;
    public float tumble;
    public Transform target_pos;
    public float moveSpeed = 5;
    public float movedistance = 8;
    bool isdestroy = false;
    Transform player;
    AudioSource sound;
    public Transform rot_target;
    float imsi_time;
    public ParticleSystem psBomb;
    // Use this for initialization
    void Start () {
        RD = GetComponentsInChildren<Rigidbody>();
        sound = psBomb.GetComponent<AudioSource>();
        exp_pos = transform.GetChild(0).GetComponent<Transform>();
        //target_pos = GameObject.Find("target_pos").transform;
        player = GameObject.Find("Player").GetComponent<Transform>();
       
    }
	
	// Update is called once per frame
	void Update () {
        
       
        if (isdestroy == false)
        {
            if (Vector3.Distance(target_pos.position, transform.position) < movedistance)
            {

                Vector3 dir = transform.position - target_pos.position;
                transform.position += -1 * dir.normalized * moveSpeed * Time.deltaTime;
                //moveSpeed = moveSpeed + 0.5f;
                transform.RotateAround(rot_target.position, Vector3.up, 50 * Time.deltaTime);
            }

            //콜라이더 없는 애들끼리 부딧히게 하기 
            if(Vector3.Distance(target_pos.position, transform.position) <4f)
            {

                for (int i = 0; i < RD.Length; i++)
                {
                    //폭발을 일으킨다
                    //플레이어 쪽으로 날아오게 한다 
                   
                    RD[i].AddExplosionForce(exp_force * 2, target_pos.position, 90 * 2);
                 
                    RD[i].angularVelocity = Random.insideUnitSphere * tumble;

                }
               
                isdestroy = true;
            }

        }
        if (isdestroy)
        {
            imsi_time += Time.deltaTime;
            for (int i = 2; i < RD.Length; i++)
            {
                RD[i].AddForce(player.position * 0.5f, ForceMode.Acceleration);
            }

            for (int i = 0; i < 2; i++)
            {
                RD[i].AddExplosionForce(10 * 2, transform.position, 5 * 2);
            }
         if(imsi_time > 10 )
            {
                gameObject.SetActive(false);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        isdestroy = true;
        for (int i = 0; i < RD.Length; i++)
        {
            //폭발을 일으킨다
            RD[i].AddExplosionForce(exp_force*2, exp_pos.position, 90*2);
            RD[i].angularVelocity = Random.insideUnitSphere * tumble;

        }

        
    }
}
