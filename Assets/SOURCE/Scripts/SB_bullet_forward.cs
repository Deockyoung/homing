using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_bullet_forward : MonoBehaviour {

    public GameObject bulletfact;
    float curtime;
    public float createTime = 0.3f;
   
    //활성화 
    SB_skill1 skill_maanger;
	// Use this for initialization
	void Start () {

        skill_maanger = GetComponentInParent<SB_skill1>();
    }
	
	// Update is called once per frame
	void Update () {

        if (skill_maanger.is_active)
        {
            curtime += Time.deltaTime;

            if (curtime > createTime)
            {
                if (bulletfact != null)
                {
                    GameObject Bullet = Instantiate(bulletfact);
                    Bullet.transform.position = transform.position;
                    Bullet.transform.forward = transform.forward;
                    curtime = 0;
                }
            }
        }
	}
}
