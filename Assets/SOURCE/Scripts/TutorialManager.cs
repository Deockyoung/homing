using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class TutorialManager : MonoBehaviour {


    public Text tutorialText;

    Animator anim;

    public GameObject tutorialHandle;

    public static TutorialManager Instance;

    public bool start_player_up = false;

    public int tutorialNum;

    Transform run_start_pos;

    Transform Player_transform;

    public GameObject tutorial_stuff; 
    HandController hand_ctrl_scr;
    HandleCheck check_scr;
   public  Transform handle_modeling;

   public bool is_once = false;
    public enum Tut_State
    {
        Idle,
        Intro,
        Up,
        Move,
        Dron,
        Obstacle,
        Go
        
    }
    public Tut_State mState;
    public float tut_rot_mount = 80;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    // Use this for initialization
    void Start()
    {
        tutorial_stuff = GameObject.Find("Handle_Tut");
        hand_ctrl_scr = GameObject.Find("Player").GetComponent<HandController>();
        run_start_pos = GameObject.Find("Run_start_pos").GetComponent<Transform>();
        Player_transform = GameObject.Find("Player").GetComponent<Transform>();
       // tutorialNum = 1;
        anim = GameObject.Find("Handle_Tut").GetComponent<Animator>();
        check_scr = handle_modeling.GetComponent<HandleCheck>();
        mState = TutorialManager.Tut_State.Idle;
       // is_once = false;
    }
 

    // Update is called once per frame
    void Update()
    {
        //튜토리얼 매니저
        //첫번째 1~7
        
     

        // 슬비 튜토리얼 버전 


        switch (mState)
        {
            case Tut_State.Idle:
                Idle();
                //처리
                break;
            case Tut_State.Up:
                Up();
                //처리
                break;

            case Tut_State.Move:
                Move();
                //처리
                break;

            case Tut_State.Dron:
                //처리\
                Dron();
                break;

            case Tut_State.Obstacle:
                //처리\
                Obstacle();
                break;

            case Tut_State.Intro:
                //처리\
                Intro();
                break;
            case Tut_State.Go:
                //처리\
                Go();
                break;
        }
        

        if (start_player_up)
        {

        }
    }

    private void Intro()
    {
      
    }

    private void Obstacle()
    {
     

    }

    private void Dron()
    {
        
    }

    private void Move()
    {

        //핸들 움직임 튜토리얼이 시작된다. 
        #region 튜토리얼 텍스트 

        
        if (tutorialNum == 0 && is_once == false)
        {

            tutorialText.text = "Go!";
            tutorialHandle.SetActive(true);
            anim.SetBool("is_tut_go", true);
        }
        
        if (tutorialNum == 1 && is_once == false)
        {
            tutorialText.text = "Left";
            anim.SetBool("is_tut_left", true);
            is_once = true;
          
        }
        else if (tutorialNum == 2 && is_once == false)
        {
            tutorialText.text = "Right";
            anim.SetBool("is_tut_right", true);
            is_once = true;
          
        }
        else if (tutorialNum == 3 && is_once == false)
        {
            tutorialText.text = "Up";
            anim.SetBool("is_tut_up",true);
            is_once = true;
        }
        else if (tutorialNum == 4 && is_once == false)
        {
            tutorialText.text = "Down";
            anim.SetBool("is_tut_down", true);
            is_once = true;
        }

        else if (tutorialNum == 5 && is_once == false)
        {
            tutorialText.text = "Go!";
            tutorialHandle.SetActive(true);
            anim.SetBool("is_tut_go", true);
        }
        else if (tutorialNum == 6 && is_once == false)
        {
            tutorialText.text = "obstacle";
            is_once = true;
        }


        #endregion



    }


    //우주선이 떠올라서 시작 지점으로 움직인다. 
    public float boot_speed = 5;

    private void Up()
    {
        Vector3 dir = run_start_pos.position - Player_transform.position;
        if(Vector3.Distance(Player_transform.position, run_start_pos.position)>1)

        {
            Player_transform.position += dir.normalized * boot_speed * Time.deltaTime;
        }

        else  if (Vector3.Distance(Player_transform.position, run_start_pos.position) < 1)

        {
            tutorialNum = 1;
            is_once = false;
            mState = Tut_State.Move;
        }

    }

    private void Idle()
    {

        //처음 시작 ui 끈 상태 

        tutorial_stuff.SetActive(false);

    }
    void Go()
    {
        //게임 시작 --> 전진가능 
        hand_ctrl_scr.is_tutorial_mode = false;
    }
}
