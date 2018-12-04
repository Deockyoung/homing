using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_rocks : MonoBehaviour {

    Transform player;
    Vector3 dir;
    Rigidbody rd;
    // stuff
    Rigidbody[] RD;
    public float exp_force = 40;
    Transform exp_pos;
    bool isdestroy = false;
    public  float movespeed;
  

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      
        rd = GetComponent<Rigidbody>();
        exp_pos = transform;
    }
    // Update is called once per frame
    void Update () {

        dir = player.position - transform.position;
        rd.AddForce(dir.normalized  * movespeed, ForceMode.Acceleration);
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
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
    */
}
