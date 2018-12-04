using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCube : MonoBehaviour {

    public float endingSpeed=1;

    public static bool endingOn;

    public GameObject endingFireButton;

    public GameObject EndingMissile;

    bool EndingUIOn;
    // Use this for initialization
    void Start () {
        print("EndingCube 넣었어?");
	}
	
	// Update is called once per frame
	void Update () {
        EndingFire();
        //ui 깜빡이기   - HandController의 Ending 함수에 있음
        if (EndingUIOn)
        {

            ///kjhkjhkj
            //GameObject.Find("Player").GetComponent<HandController>().Ending();
        }
    }

    //트리거에 들어갔을때 속도줄이고 자동주행
    //스스로 움직이지 못함
    //UI 반짝이게 하기
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ////사운드 재생
            //print("사운드 테스트");
            //SoundManager_Voice.isPlaying = true;
            //GameObject.Find("SoundManager_Voice").GetComponent<SoundManager_Voice>().voiceNum = 1;


            //스피드 다운
            HandController.maxSpeed = endingSpeed;

            //자동전진
            //endingOn = true;

            //UI 깜빢이기 
            EndingUIOn = true;
            GameObject.Find("Player").GetComponent<HandController>().Ending();


            //10초후 엔딩 Fire 함수 실행
            Invoke("EndingFire", 5);
        }
    }


    void EndingFire()
    {
        //엔딩때 사용할 미사일 발사

        //쿨링팩 발사할 버튼 생성 (반짝이기)
        //endingFireButton.SetActive(true);
        //발사하면 미사일 앞으로 발사
        //if (EndingFireButton.EndingFireButtonOn)
        //{
        //    //비행기에 달려있던 오브젝트 ON 하고 앞으로 전진발사하도록 한다
        //    EndingMissile.SetActive(true);


        //}
    }
}
