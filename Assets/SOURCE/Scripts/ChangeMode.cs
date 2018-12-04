using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {


    public float speedUp;
    public float speedDown;
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
    /// 
  
    // 애니메이션 넣기
    public Animator Shooting;
    public Animator Normal;





    //슈팅모드 -> 노말모드 변경
    public static bool ShootingMode;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {




        if (ShootingMode)
        {
            Shooting.SetTrigger("Shooting");
            HandController.maxSpeed = speedDown;
            ////////////////////////////////보스모드////////////////////////////////
            // 노말모드 
            ShootingScript.GetComponent<PlayerFire>().enabled = false;
            // 슈팅모드 
            ShootingScript.GetComponent<PlayerShooting>().enabled = true;
            //슈팅 모드에서 에임 생성
            ShootingAimLeft.SetActive(true);
            ShootingAimRight.SetActive(true);


            GunLeft.SetActive(true);
            GunRight.SetActive(true);
            //////////////////////////////////////////////////////////////
        }
        else
        {
            Normal.SetTrigger("Normal");
            HandController.maxSpeed = speedUp;
            ////////////////////////////////보스모드////////////////////////////////
            // 노말모드 
            ShootingScript.GetComponent<PlayerFire>().enabled = true;
            // 슈팅모드 
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
