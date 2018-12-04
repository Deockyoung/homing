using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_asteroidCTRL : MonoBehaviour {

    Rigidbody[] RD;
    Transform exp_pos;
    public float exp_force = 4;
    public float tumble;
    Transform target_pos;
    public float moveSpeed = 5;
    float movedistance = 8;
    bool isdestroy = false;
    float curtime;
    float imsi_time;
    AudioSource sound;
    SphereCollider sc;
    public ParticleSystem psBomb;
    // Use this for initialization
    void Start () {
        RD = GetComponentsInChildren<Rigidbody>();
        exp_pos = transform.GetChild(0).GetComponent<Transform>();
        target_pos = GameObject.Find("target_pos").transform;
        sc = GetComponent<SphereCollider>();
      //  sound = psBomb.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        
        if (isdestroy == false)
        {
            if (Vector3.Distance(target_pos.position, transform.position) < movedistance)
            {
                Vector3 dir = transform.position - target_pos.position;
                transform.position += -1 * dir.normalized * moveSpeed * Time.deltaTime;
                
            }
        }
        
        if(isdestroy)
        {
            
            imsi_time += Time.deltaTime;
            for (int i = 0; i < RD.Length; i++)
            {
                RD[i].AddExplosionForce(exp_force * 4, exp_pos.position, 90 * 2);

            }

            if (imsi_time > 10)
            {
                gameObject.SetActive(false);

            
            }
            

            curtime += Time.deltaTime;
            if(curtime > 10)
            {
                gameObject.SetActive(false);
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("bullet"))
        {
            isdestroy = true;
            for (int i = 0; i < RD.Length; i++)
            {
                //폭발을 일으킨다
                RD[i].AddExplosionForce(exp_force * 4, exp_pos.position, 90 * 2);
                RD[i].angularVelocity = Random.insideUnitSphere * tumble;

            }
        }
    }

    */
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Contains("bullet"))
        {
            //나의 콜리전을 우선 끈다 
            sc.enabled = false;

            isdestroy = true;
            for (int i = 0; i < RD.Length; i++)
            {
                //폭발을 일으킨다
                RD[i].AddExplosionForce(exp_force * 4, exp_pos.position, 90 * 2);
                RD[i].angularVelocity = Random.insideUnitSphere * tumble;


            }
            psBomb.transform.position = collision.transform.position;
            psBomb.Stop();
            psBomb.Play();
            sound.Stop();
            sound.Play();
            PlayerFire.deactiveListLeft.Add(collision.gameObject);
            PlayerFire.deactiveListRight.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

    }
}
