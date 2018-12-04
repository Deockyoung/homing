using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {


    //보스 슈팅모드 스크립트 on
    public GameObject ShootingScript;

    //보스 슈팅모드 무기 on
    public GameObject GunLeft;
    public GameObject GunRight;

    //에임에 대한 오브젝트
    public GameObject ShootingAimLeft;
    public GameObject ShootingAimRight;

    //플레이어 지나갔을때 문 생성
    public GameObject BigDoor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //////총모드로 바뀌는 UI 넣기 
        


        ////////////////////////////////보스모드////////////////////////////////
        // 노말모드 off
        ShootingScript.GetComponent<PlayerFire>().enabled = false;
        // 슈팅모드 on
        ShootingScript.GetComponent<PlayerShooting>().enabled = true;
        //슈팅 모드에서 에임 생성
        ShootingAimLeft.SetActive(true);
        ShootingAimRight.SetActive(true);

        
        GunLeft.SetActive(true);
        GunRight.SetActive(true);
        ////////////////////////////////보스모드////////////////////////////////


        BigDoor.SetActive(true);
    }



}
