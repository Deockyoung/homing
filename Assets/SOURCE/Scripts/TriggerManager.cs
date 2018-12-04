using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    //우주선 오브젝트
    public GameObject playerShip;


    
    public Animator leverAnim;
    public Transform lever;

    public float objectSpeed;

    //핸들 
    public GameObject handle;

    //튜토리얼 우주선
    public GameObject tutorialSpace;

    //버튼
    public GameObject button;
    //UI 오브젝트
    public GameObject uiObject;
    //라이트
    public GameObject light;
    HandController hand_sctr;
    //인트로 우주선 타겟
    public Transform introTarget;

    //인트로 오브젝트 움직임 속도
    float step;

    //레버 에니메이션 끄기
    bool leverMove;

    //엔진소리 한번만 나오도록 하기
    bool enginePlaying;

    // Use this for initialization
    void Start () {
        leverMove = true;
        enginePlaying = true;
        hand_sctr = GameObject.Find("Player").GetComponent<HandController>();
    }
	
	// Update is called once per frame
	void Update () {
        // The step size is equal to speed times frame time.
        step = objectSpeed * Time.deltaTime;



        //인트로 레버 트리거 작동
        if (leverOne.leverOneEnter && leverTwo.leverTwoEnter)
        {


            //시작할떄 엔진소리

            //한번만 플레이하도록 만들기!
            

        

            Invoke("ButtonOn", 2f);
            Invoke("UIOn", 3f);
            Invoke("LightOn", 4);
            Invoke("TutorialFlightOn", 5);
            Invoke("HandleOn", 6);
            //ui가 전부 켜진다. 

            

            //애니메이션 작동
            //애니메이션을 한번 작동하면 꺼지도록 한다
            if (leverMove)
            {
                leverMove = false;
                leverAnim.SetTrigger("leverMove");
                leverMove = false;
                print("leverMove:" + leverMove);
            }


        }

        //맨 위로 올라가면 핸들과 튜토리얼 비행기 나오도록 한다
        //IntroStart 에서 true 값 받는다


    }



    bool imsi = false;
    void HandleOn()
    {
        handle.SetActive(true);

        if (imsi == false)
        {
            TutorialManager.Instance.tutorial_stuff.SetActive(true);
            TutorialManager.Instance.mState = TutorialManager.Tut_State.Up;
            hand_sctr.handle_on = true;
             imsi = true;
        }


    }

    void TutorialFlightOn()
    {
        handle.SetActive(true);
      
    }

    void ButtonOn()
    {
        button.SetActive(true);
        
    }

    void UIOn()
    {
        uiObject.SetActive(true);
   
    }

    void LightOn()
    {
        light.SetActive(true);

        //엔진소리 플레이
        if (enginePlaying)
        {
            SoundManager.Instance.Play(SoundManager.Sounds.FlightEngine);
            enginePlaying = false;
        }
    }

}





