using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject Hanger;
    HandController hc;
    // Use this for initialization
    void Start () {
        hc = GameObject.Find("Player").GetComponent<HandController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Speed up???!");
            HandController.maxSpeed = GameObject.Find("Player").GetComponent<ChangeMode>().speedUp = 500;
            print(" HandController.maxSpeed:" + HandController.maxSpeed);


            //총알, 미사일 속도 변경 
            //GameObject.Find("BulletRight").GetComponent<BulletRight>().bulletSpeed = 2000;
            //GameObject.Find("BulletLeft").GetComponent<BulletLeft>().bulletSpeed = 2000;
            //GameObject.Find("Missile").GetComponent<Missile>().missileSpeed = 2000;
            GameObject.Find("Player").GetComponent<HandController>().vibsum = 0;

            hc.StartCoroutine("CoSimulVib");
            //Hanger제거
            Destroy(Hanger);

        }
    }



}
