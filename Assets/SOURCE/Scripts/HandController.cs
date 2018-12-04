using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{


    public GameObject emergencyState;

    //친구비행기와의 거리를 구한다
    public Transform friendFlight;
    public static float friendSpeed;
    public static float friendSpeed2;
    public float friendSpeedChange;

    //처음 시작위치
    Transform game_start_Pos;


    public GameObject frontCube;
    float flightRotation;
    float rotationScale;

    public float settingSpeed = 5;


    public float minAngle = -90;
    public float maxAngle = 90;


    //캐릭터 컨트롤러
    CharacterController cc;


    public Transform leftHand;
    public Transform rightHand;
    public GameObject flight;

    //오큘러스 컨트롤러 가져오기
    public OVRInput.Controller leftController;
    public OVRInput.Controller rightController;



    //수직이동 테스트위함
    public GameObject verticalCube;

    //스피드
    public float forwardSpeed = 200;
    public float rotationSpeed = 50;
    public float verticalSpeed = 50;

    //비행기 파티클
    public ParticleSystem starEffect;

    //카메라 z축 비행기 회전과 같이 움직이도록 하기 위함
    public Camera centerCamera;


    //핸들
    public GameObject handle;
    float handleMinAngle = -30;
    float handleMaxAngle = 30;

    //튜토리얼 비행기
    public Transform tutorialFlight;

  

    float controllerRotation;


    //시뮬레이터 조정값
    public float PNI_SWAY = 1000f;
    public float PNI_SURGE = 1000f;
    public float PNI_ROLL = 1000f;
    public float PNI_PITCH = 1000f;

    //시뮬 Y 값
    public float PNI_HEAVE = 100;



    //z회전값을 y회전값으로 누적시키는 수
    float yRot;

    float xRot;

    float cSpeed = 0;

    //핸들 닿았는지 체크
    bool checkHandle;

    //보스모드에서의 비행기 움직임
    public static bool bossModeRotation;

    //피격효과 유리
    public GameObject glass;

    //피격효과 UI
    public Animator UIAnim;
    public Animator EmergencyAnim;

    //튜토리얼 모드 
   public  bool is_tutorial_mode = true;
    public bool handle_on = false;
    void Start()
    {
        cc = GetComponent<CharacterController>();

        postpostpost.vignette.enabled = false;
        is_tutorial_mode = true;
        game_start_Pos = GameObject.Find("Game_start_Pos").GetComponent<Transform>();
        //플레이어의 처음 시작 위치 설정  (게임 시작 위치 )
        transform.position = game_start_Pos.transform.position;
        transform.forward = game_start_Pos.forward;
    }

    float curtime;
    void Update()
    {

        //튜토리얼 모드일때 키입력을 막고 핸들 애니메이션을 활성화
     


        //핸들에 손 닿았는지 체크
        if (handle.GetComponent<HandleCheck>().checkHands)
        {



            Quaternion leftHandRotation = OVRInput.GetLocalControllerRotation(leftController);
            Quaternion rightHandRotation = OVRInput.GetLocalControllerRotation(rightController);

            Vector3 leftEulerAngles = leftHandRotation.eulerAngles;
            Vector3 rightEulerAngles = rightHandRotation.eulerAngles;

            if (leftEulerAngles.x > 180)
            {
                leftEulerAngles.x = leftEulerAngles.x - 360;
            }
            if (rightEulerAngles.x > 180)
            {
                rightEulerAngles.x = rightEulerAngles.x - 360;
            }

            controllerRotation = (leftEulerAngles.x + rightEulerAngles.x) / 2;


            ///////////////////////컨트롤러 각도 가져오기



            //Mathf.Atan2 이용해서 좌우 컨트롤러 각도 구한다
            float atan2angle = Mathf.Atan2(rightHand.transform.localPosition.y - leftHand.transform.localPosition.y, rightHand.transform.localPosition.x - leftHand.transform.localPosition.x) * Mathf.Rad2Deg;

            //Debug.Log("Angle : " + atan2angle);

            //yRot 누적값을 구해서 좌우 회전을줌 
            yRot += -atan2angle * Time.deltaTime;

            // 상하 회전
            xRot = controllerRotation / 2;

            //float rotationFlight = Mathf.Abs(leftHand.transform.position.y - rightHand.transform.position.y) * rotationSpeed;

            ///////////상하 (나중)///////// --미세조정필요!


            //if (controllerRotation > 0.2)
            //{
            //    //transform.rotation = Quaternion.Slerp(transform.rotation, Up, Time.deltaTime * verticalSpeed);
            //    flightRotation += (-verticalSpeed) * Time.deltaTime;
            //}

            //if (controllerRotation < -0.2)
            //{
            //    //transform.rotation = Quaternion.Slerp(transform.rotation, Down, Time.deltaTime * -verticalSpeed);
            //    flightRotation += (verticalSpeed) * Time.deltaTime;
            //}
            ///////////상하 (나중)/////////


            //print("controllerRotation:" + controllerRotation);

            //핸들 움직이기
            handle.transform.localRotation = Quaternion.Euler(-controllerRotation, atan2angle, 0);






            //입력받은 값으로 큐브를 회전시킨다;  flightRotation- 상하 우선 없앰 //atan2angle
            frontCube.transform.rotation = Quaternion.Euler(xRot, yRot, 0);





            if (is_tutorial_mode == true && handle_on)
            {
               
                //튜토리얼 시 내가 움직이기
                //transform.localRotation = Quaternion.Euler(controllerRotation / 3, 0, atan2angle / 3);
                
               
            }

            else if(is_tutorial_mode == false)
            {

                //전진--자동전진
                ForwardFlight();

            }



            ///////////////////////시뮬레이터 구현////////////////////


            ////x축 이동
            //PNI_Setting.Instance.axes.sway += (int)(yRot * PNI_SWAY);
            //z축 회전
            PNI_Setting.Instance.axes.roll = 10000+(int)(-atan2angle * PNI_ROLL);


            //PNI_Setting.Instance.axes.sway = Mathf.Clamp(PNI_Setting.Instance.axes.sway, 0, 20000);
            PNI_Setting.Instance.axes.roll = Mathf.Clamp(PNI_Setting.Instance.axes.roll, 0, 20000);

            ///////////////////////시뮬레이터 구현////////////////////
        }
        else
        {

            return;
        }

        CheckDistanceFriend();
    }

    private void CheckDistanceFriend()
    {
        //친구 비행기와 나의 거리를 구한다
        float dist = Vector3.Distance(friendFlight.position, transform.position);


        friendSpeed = (1 / dist) * friendSpeedChange;

        //print("friendSpeed:" + friendSpeed);


    }

    //속도넣기
    public Text speedText;


    public float acceleration = 1;
    public static float maxSpeed = 250;
    public float speedChange = 0.5f;

    Vector3 dir = new Vector3(0, 0, 1);

    public bool testMode = false;
    private void ForwardFlight()
    {

        //transform.forward += frontCube.transform.forward * settingSpeed * Time.deltaTime;

        //가속 주기위한 코드
        //cc.Move(transform.forward * acceleration * Time.deltaTime);


        //float xRot = transform.rotation.x * 100;
        //x축 회전 PNI_PITCH
        //PNI_Setting.Instance.axes.pitch = (int)(xRot * PNI_PITCH);
        //PNI_Setting.Instance.axes.pitch = Mathf.Clamp(PNI_Setting.Instance.axes.pitch, 0, 20000);

        //print("PNI_Setting.Instance.axes.pitch:" + PNI_Setting.Instance.axes.pitch);

        //print("Spped?:" + maxSpeed);


        ////속도는 minSpeed 부터 시작해서 maxSpeed 까지 올라간다(가속도)
        //if (acceleration < maxSpeed)
        //{
        //    acceleration += speedChange;
        //    //print("acceleration:" + acceleration);
        //}



        //컨트롤러 사용 모드와 아닌모드 나눌것(엔딩때문)
        if (EndingCube.endingOn)
        {
            //자동전진모드
            transform.forward += frontCube.transform.forward * settingSpeed * Time.deltaTime;
            cc.Move(transform.forward * acceleration * Time.deltaTime);
            print("endingcube");
        }


        else
        {

            /////////////////// 컨트롤러 사용//////////////////////
            ////PrimaryHandTrigger 좌우 눌렀을때 전진
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {

                transform.forward += frontCube.transform.forward * settingSpeed * Time.deltaTime;



                //가속 주기위한 코드
                //cc.Move(transform.forward * acceleration * Time.deltaTime);



                //float xRot = transform.rotation.x * 100;
                //x축 회전 PNI_PITCH
                //PNI_Setting.Instance.axes.pitch = (int)(xRot * PNI_PITCH);
                //PNI_Setting.Instance.axes.pitch = Mathf.Clamp(PNI_Setting.Instance.axes.pitch, 0, 20000);

                //print("PNI_Setting.Instance.axes.pitch:" + PNI_Setting.Instance.axes.pitch);



                //속도는 minSpeed 부터 시작해서 maxSpeed 까지 올라간다(가속도)
                if (acceleration < maxSpeed)
                {
                    acceleration += speedChange;
                    //print("acceleration:" + acceleration);
                }


                cc.Move(transform.forward * acceleration * Time.deltaTime);

            }

            else
            {
                // SoundManager.Instance.Stop();


                //while 문 사용해서 갑자기 한번에 값이 들어갔음 
                //Invoke("SlowDown",0);
                if (acceleration > 0)
                {
                    acceleration -= 2f;
                    //cc.Move(Vector3.forward * acceleration * Time.deltaTime);
                    //transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

                    cc.Move(transform.forward * acceleration * Time.deltaTime);

                }
            }


        }

        speedText.text = acceleration.ToString();
    }

    //void SlowDown()
    //{

    //    while (acceleration > 0)
    //    {
    //        acceleration -= 2f;
    //        //cc.Move(Vector3.forward * acceleration * Time.deltaTime);
    //        //transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

    //        cc.Move(transform.forward * acceleration * Time.deltaTime);

    //    }
    //}

    public AudioClip damage_se;
    AudioSource audiossssss;
    public PostProcessingProfile postpostpost;

    bool emergency;
    public void Damage()
    {
        audiossssss = GetComponent<AudioSource>();

        audiossssss.PlayOneShot(damage_se);

        print("Damage????");
        //시뮬레이터 진동을 준다

  

        //창문 피격효과
        glass.SetActive(true);

        //Front UI 깜빡임
        UIAnim.SetTrigger("UIDamage");

        emergency = true;
        //경고 UI 깜빡임

        EmergencyAnim.SetTrigger("Emergency");

        postpostpost.vignette.enabled = true;

        Invoke("offoffoff", 2);
        //사운드

        //경고음 1번

        // 화면 깜빡이기
        // 2초동안 깜빡인다




        //진동넣기 
        vibsum = 0;
        StartCoroutine("CoSimulVib");
        //SimulVib();


    }

    //맞고 있을때 시간 측정하는 값

    public float vibsum;
    IEnumerator CoSimulVib()
    {
        while (vibsum < 3)
        {
            PNI_Setting.Instance.axes.heave = 10000 + (int)(PNI_HEAVE);
            vibsum += 0.05f;
            PNI_HEAVE = -(int)(PNI_HEAVE);
            yield return new WaitForSeconds(0.05f);
        }
    }



    public void Ending()
    {

        print("Ending?????");
        //시뮬레이터 진동을 준다


        //glass.SetActive(true);

        //Front UI 깜빡임
        UIAnim.SetTrigger("UIDamage");

        //경고 UI 깜빡임
        EmergencyAnim.SetTrigger("Emergency");

        Invoke("offoffoff", 2);
    }

    void offoffoff()
    {
        postpostpost.vignette.enabled = false;
        emergency = false;
        //emergencyState.SetActive(false);
    }
}