using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMissileShot : MonoBehaviour {

    public float missileSpeed;
    public Transform earthPosition;
    Vector3 dir;

    //public ParticleSystem earthMissile;
    //AudioSource sound;

    EarthCtrl earthCtrl;
    // Use this for initialization
    void Start () {
        earthCtrl = GameObject.Find("Earth").GetComponent<EarthCtrl>();
        //sound = earthMissile.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //타겟을 지구로 잡을것
        earthCtrl = GameObject.Find("Earth").GetComponent<EarthCtrl>();
        dir = earthCtrl.transform.position - transform.position;
        transform.position += dir.normalized * missileSpeed * Time.deltaTime;
        //transform.forward = dir.normalized;
        
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Earth")
        {
            print("EndingMissileShot 에서 Earth???");
            // 폭발효과 발생
            // bomb 위치에 폭발 효과 발생 
            //earthMissile.transform.position = transform.position;
            //earthMissile.Stop();
            //earthMissile.Play();
            //sound.Stop();
            //sound.Play();
            earthCtrl.StartCoroutine(earthCtrl.EarthChange());
            //지구 텍스쳐 변경 (자연스럽게)
        }



    }

    //private void OnTriggerEnter(Collider collision)
    //{

    //    if (collision.gameObject.tag == "Earth")
    //    {
    //        print("EndingMissileShot 에서 Earth???");
    //        // 폭발효과 발생
    //        // bomb 위치에 폭발 효과 발생 
    //        //earthMissile.transform.position = transform.position;
    //        //earthMissile.Stop();
    //        //earthMissile.Play();
    //        //sound.Stop();
    //        //sound.Play();
    //        earthCtrl.StartCoroutine(earthCtrl.EarthChange());
    //        //지구 텍스쳐 변경 (자연스럽게)
    //    }



    //}


}
