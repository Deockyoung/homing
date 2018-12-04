using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomSpeedUp : MonoBehaviour {


    /// <summary>
    /// ///////////////////////////////
    /// </summary>
    //보스 슈팅모드 스크립트 on
    public GameObject ShootingScript;

    //보스 슈팅모드 무기 on
    public GameObject GunLeft;
    public GameObject GunRight;

    //에임에 대한 오브젝트
    public GameObject ShootingAimLeft;
    public GameObject ShootingAimRight;
    /// <summary>
    /// ///////////////////////////////
    /// </summary>



    public float speedUp = 400;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Speed up???!");
            HandController.maxSpeed = speedUp;
            print(" HandController.maxSpeed:" + HandController.maxSpeed);




            ////////////////////////////////보스모드////////////////////////////////
            // 노말모드 off
            ShootingScript.GetComponent<PlayerFire>().enabled = true;
            // 슈팅모드 on
            ShootingScript.GetComponent<PlayerShooting>().enabled = false;
            //슈팅 모드에서 에임 생성
            ShootingAimLeft.SetActive(false);
            ShootingAimRight.SetActive(false);


            GunLeft.SetActive(false);
            GunRight.SetActive(false);
            //////////////////////////////////////////////////////////////



        }
    }

}
