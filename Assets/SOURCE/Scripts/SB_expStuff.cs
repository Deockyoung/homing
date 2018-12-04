using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_expStuff : MonoBehaviour {
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
    public bool isTest = false;
    // Use this for initialization
    void Start()
    {
        RD = GetComponentsInChildren<Rigidbody>();
        sound = psBomb.GetComponent<AudioSource>();
        exp_pos = transform.GetChild(0).GetComponent<Transform>();
        target_pos = GameObject.Find("target_pos").transform;
        player = GameObject.Find("Player").GetComponent<Transform>();
      
    }

    // Update is called once per frame
    void Update()
    {
        exp_pos = transform.GetChild(0).GetComponent<Transform>();
        RD = GetComponentsInChildren<Rigidbody>();
        if (isdestroy == false)
        {
            target_pos = GameObject.Find("target_pos").transform;
            

            //콜라이더 없는 애들끼리 부딧히게 하기 
            if (Vector3.Distance(target_pos.position, transform.position) < 4f)
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
                RD[i].AddForce(target_pos.position * 0.5f, ForceMode.Acceleration);
            }

            for (int i = 0; i < 2; i++)
            {
                RD[i].AddExplosionForce(10 * 2, transform.position, 5 * 2);
            }
            if (imsi_time > 10)
            {
                gameObject.SetActive(false);
            }
        }

        if(isTest)
        {
            isdestroy = true;
            for (int i = 0; i < RD.Length; i++)
            {
                //폭발을 일으킨다
                RD[i].AddExplosionForce(exp_force * 2, exp_pos.position, 90 * 2);
                RD[i].angularVelocity = Random.insideUnitSphere * tumble;

            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        isdestroy = true;
        for (int i = 0; i < RD.Length; i++)
        {
            //폭발을 일으킨다
            RD[i].AddExplosionForce(exp_force * 2, exp_pos.position, 90 * 2);
            RD[i].angularVelocity = Random.insideUnitSphere * tumble;

        }


    }
}
