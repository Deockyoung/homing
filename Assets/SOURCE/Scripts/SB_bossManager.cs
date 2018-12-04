
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SB_bossManager : MonoBehaviour {


    // 보스의 공격 형태
    //1. 적을 생성해서 공격
    //2. 사방에 미사일을 부린다
    //3. 스킬을 쓴다
    public float lifeTime = 60;
    float curLifeTime;
    AudioSource[] destroy_audio;
    AudioSource hitted_sound;
    public enum BossState
    {
        Idle,
        BaseAttack,
        MakeDrone,
        CircleAttack,
        Skill_2,
        Demage,
        Destroy,
        Wait

    }
    public BossState mState;
    public  ParticleSystem dron_start_ps;
    public Transform[] dron_pos;
    public int[] boss_pattern;
    #region 드론 생성 프로퍼티
    int drone_index = 0;
    float curtime;
    public float droneCreateTime = 0.5f;
    public GameObject drone;
    #endregion

    #region skill_2 프로퍼티
    Transform skill_2_pos;
    public GameObject skill2_fact;
    public ParticleSystem aura_ps;
    public float skill2_time = 2;
    Transform target;
    float fireTime;
    bool isfire_play = false;
    ParticleSystem[] fire;
    AudioSource fire_sound;
    #endregion
    public AudioSource circle_skill_sound;

    #region 랜덤 움직임 
    public   Transform[] boss_path;
    public int boss_index = 1;
    float pathSpeed = 20;
    #endregion

    #region skill_1 프로퍼티  
    SB_skill1[] skill_1_scr;
    public float skill_1_time = 2;
    bool skill_1_start = false;
    ParticleSystem skill1_exp;


   public float demage_speed = 1;
    public float demage_amount =1;
    bool demage = false;


    private Vector3 originPosition;

    private Quaternion originRotation;

    public float shake_decay = 1f;

    public float shake_intensity = .05f;



    private float temp_shake_intensity = 0;

    #endregion


    #region 기본 공격  

    public Transform[] small_laser_pos;
    public Transform[] big_laser_pos;
    public GameObject small_laser_FAC;
    public GameObject big_laser_FAC;

    GameObject[] small_laser;
    GameObject[] big_laser;
    bool is_small_finished = false;
    public float base_attack_createTime = 0.7f;
    public int baseAttack_int = 10;
    int curAttackCount = 0;
    float imsi_time;
    //기본 공격
    public float delay_time = 3f;
    int smal_int = 0;
    int big_int = 0;
    #endregion

    public float boss_movespeed = 0.5f;


    #region 디스트로이 프로퍼티

    ParticleSystem[] destroy_ps;

    #endregion

    // Use this for initialization
    void Start()
    {
        //보스는 시작했을 때 대기 상태였다가 --> 트리거 안쪽에 들어가면 움직이기 시작한다.
        
        dron_pos = GameObject.Find("drone_pos").GetComponentsInChildren<Transform>();
        //dron_start_ps = GameObject.Find("shockWave_red_combo").GetComponent<ParticleSystem>();
       
        skill_2_pos = gameObject.transform.GetChild(5).transform.GetComponent<Transform>();
        aura_ps = skill_2_pos.transform.GetChild(0).transform.GetComponent<ParticleSystem>();
        aura_ps.Stop();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fire = gameObject.transform.GetChild(4).transform.GetComponentsInChildren<ParticleSystem>();
        boss_path =transform.parent.GetChild(3).GetComponentsInChildren<Transform>();
        skill_1_scr = transform.GetComponentsInChildren<SB_skill1>();
        skill1_exp = transform.GetChild(2).GetComponent<ParticleSystem>();
        //보스 패턴 정해놓기
        boss_pattern = new int[10] { 1,4,3,1,4,2,1,3,4,1};
        fire_sound = gameObject.transform.GetChild(4).transform.GetComponent<AudioSource>();
        circle_skill_sound = skill_2_pos.GetComponent<AudioSource>();
        destroy_audio = transform.GetChild(6).GetComponents<AudioSource>();
        hitted_sound = GetComponent<AudioSource>();
        mState = BossState.Wait;
    }
	
	// Update is called once per frame
	void Update () {


             

        //기본 움직임 
        //boss_path를 따라 움직인다. 
        if (demage == false)
        {
            if (boss_index <= (boss_path.Length - 1))
            {

                Vector3 dir = transform.position - boss_path[boss_index].position;
                transform.position += dir * -1* boss_movespeed * Time.deltaTime;
                Vector3.MoveTowards(transform.position, boss_path[boss_index].position, Time.deltaTime * pathSpeed);
                if (Vector3.Distance(transform.position, boss_path[boss_index].position) < 0.5f)
                {
                    boss_index++;
                }
              
            }
            else if (boss_index > (boss_path.Length - 1))
            {
                boss_index = 1;
            }
            //플레이어를 쳐다봐야함 
            transform.LookAt(target);

            lifeTime -= Time.deltaTime;
            if(lifeTime <=0)
            {
                mState = BossState.Destroy;
                
            }
        }

        if (temp_shake_intensity > 0)
        {

            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;

            transform.rotation = new Quaternion(

                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,

                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,

                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,

                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);

            temp_shake_intensity -= shake_decay;

        }


        switch (mState)
        {
            case BossState.Idle:
                Idle();
                //처리
                break;
            case BossState.BaseAttack:
                BaseAttack();
                //처리
                break;

            case BossState.MakeDrone:
                MakeDrone();
                //처리
                break;

            case BossState.CircleAttack:
                //처리\
                CircleAttack();
                break;
            case BossState.Skill_2:
                //처리\
                Skill_2();
                break;
            case BossState.Demage:
                //처리\
                Demage();
                break;
            case BossState.Destroy:
                //처리\
                Destroy();
                break;
            case BossState.Wait:
                //처리\
                Wait();
                break;
        }
    }
 
    private void CircleAttack()
    {
        demage = false;
        if (skill_1_start == false)
        {
            if (curtime > skill_1_time )
            {
                skill1_exp.Stop();
                skill1_exp.Play();
                circle_skill_sound.Play();
                //여러 미사일 사방으로 발사
                for (int i = 0; i < skill_1_scr.Length; i++)
                {
                    skill_1_scr[i].is_active = true;
                }
                skill_1_start = true;
              
            }
        }
        curtime += Time.deltaTime;
        //2초동안 발표
        if (curtime > skill_1_time*4 && skill_1_start)
        {
            //여러 미사일 사방으로 발사
            for (int i = 0; i < skill_1_scr.Length; i++)
            {
                skill_1_scr[i].is_active = false;
            }
            skill_1_start = false;
            curtime = 0;
            skill1_exp.Stop();
            circle_skill_sound.Stop();
            mState = BossState.Idle;
        }
        
    }

    private void MakeDrone()
    {
        if (drone_index < dron_pos.Length)
        {
            curtime += Time.deltaTime;
            //정해진 위치에 드론 생성
            if (curtime >= droneCreateTime)
            {
                //드론 시작 이펙트 플레이
                ParticleSystem drone_ps = Instantiate(dron_start_ps);
                drone_ps.transform.position = dron_pos[drone_index].position;
                drone_ps.Stop();
                drone_ps.Play();
                //드론 생성
                GameObject Enemy_dron = Instantiate(drone);
                Enemy_dron.transform.position = dron_pos[drone_index].position;
                Enemy_dron.transform.forward = dron_pos[drone_index].forward;
                //인덱스 늘리기
                drone_index++;

                curtime = 0;
                droneCreateTime = Random.Range(0.5f, 1.2f);
            }
            if(drone_index >= dron_pos.Length)
            {
                //다 생성하면 대기 상태로 돌아가기
                drone_index = 0;
                mState =  BossState.Idle;
            }
        }
    }

    void Skill_2()
    {
        demage = false;
        //중앙에서 큰 미사일이 나감
        //아우라 플레이
        aura_ps.Play();
        curtime += Time.deltaTime;
        fireTime += Time.deltaTime;
        if (curtime > skill2_time)
        {
            //미사일 발사
            GameObject skill2 = Instantiate(skill2_fact);
            skill2.transform.position = skill_2_pos.position;
            skill2.transform.forward = skill_2_pos.forward;
            curtime = 0;
        }
        if (isfire_play == false && fireTime > 5)
            {
                for (int i = 0; i < fire.Length; i++)
                {

                    fire[i].Stop();
                    fire[i].Play();
                    
                }
            fire_sound.Play();
            isfire_play = true;
                fireTime = 0;
        }
        //플레이
        if(isfire_play && fireTime > 5)
        {
            for (int i = 0; i < fire.Length; i++)
            {
                fire[i].Stop();
                fire_sound.Stop();
            }
            isfire_play = false;
            fireTime = 0;
            aura_ps.Stop();
            mState = BossState.Idle;
        }
       
    }
    int boss_pattern_index = 0; 
    private void Idle()
    {
        Reset_ps();
        //랜덤으로 스킬 사용
        demage = false;
        //미리 정해놓은 패턴 

        //오류ㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠ
        mState = (BossState)boss_pattern[boss_pattern_index];
        boss_pattern_index++;

        //인덱스가 다 돌면 처음으로 이동 
        if(boss_pattern_index >= boss_pattern.Length)
        {
            boss_pattern_index = 0;
        }

        //무작위 랜덤
        //   mState = (BossState)Random.Range(1, 5);

    }

   public void Demage()
    {
        curtime += Time.deltaTime;
        originPosition = transform.position;
        originRotation = transform.rotation;
        hitted_sound.Play();
        temp_shake_intensity = shake_intensity;

        if(curtime>0.03f)
        {
            mState = BossState.Idle;
        }

    }

    public bool boss_dead = false;
    public float down_speed =2f;
    public float destroyTime = 3;
    
    void Destroy()
    {
      
        if (boss_dead == false)
        {
            Reset_ps();
            TempShake();
            for (int i = 0; i < destroy_audio.Length; i++)
            {
                destroy_audio[i].Play();
            }
            demage = true;

            destroy_ps = transform.GetChild(6).GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < destroy_ps.Length; i++)
            {
                destroy_ps[i].Play();
            }
            boss_dead = true;
            curtime = 0;
        }
        if(boss_dead)
        {
            curtime = Time.deltaTime;
            transform.position += transform.up * -1 * down_speed;

            if (curtime > destroyTime)
            {
                Reset_ps();
                gameObject.SetActive(false);
                Destroy(gameObject);
               
            }

        }
    }

    void Reset_ps()
    {
        //동그란 파티클 없애기
        for (int i = 0; i < skill_1_scr.Length; i++)
        {
            skill_1_scr[i].is_active = false;
        }
        skill_1_start = false;
        //화염 없애기 
        for (int i = 0; i < fire.Length; i++)
        {
            fire[i].Stop();
        }
        
        isfire_play = false;
        fireTime = 0;
        aura_ps.Stop();
        skill1_exp.Stop();
        circle_skill_sound.Stop();
    }
   
    void BaseAttack()
    {
        small_laser = new GameObject[small_laser_pos.Length];
        big_laser = new GameObject[big_laser_pos.Length];
        if (curAttackCount > baseAttack_int)
        {
            curAttackCount = 0;
            curtime = 0;
            mState = BossState.Idle;
        }
        curtime += Time.deltaTime;
        //작은애
        if (curtime >= base_attack_createTime)
        {
            if (is_small_finished == false)
            {
                imsi_time += Time.deltaTime;

                if (imsi_time > delay_time)
                {

                    small_laser[smal_int] = Instantiate(small_laser_FAC);
                    small_laser_pos[smal_int].GetChild(0).GetComponent<ParticleSystem>().Play();
                    small_laser[smal_int].transform.position = small_laser_pos[smal_int].position;
                    small_laser[smal_int].transform.forward = small_laser_pos[smal_int].forward;
                    smal_int++;
                    imsi_time = 0;

                    if (smal_int == small_laser_pos.Length - 1)
                    {
                        small_laser[smal_int] = Instantiate(small_laser_FAC);
                        small_laser[smal_int].transform.position = small_laser_pos[smal_int].position;
                        small_laser[smal_int].transform.forward = small_laser_pos[smal_int].forward;
                        smal_int++;
                        smal_int = 0;
                        imsi_time = 0;

                        is_small_finished = true;
                    }
                }
            }

            if (is_small_finished)
            {
                imsi_time += Time.deltaTime;
                if (imsi_time > delay_time)
                {

                    big_laser[big_int] = Instantiate(big_laser_FAC);
                    big_laser[big_int].transform.position = big_laser_pos[big_int].position;
                    big_laser[big_int].transform.forward = big_laser_pos[big_int].forward;
                    big_int++;
                    imsi_time = 0;

                    if (big_int == big_laser_pos.Length - 1)
                    {
                        big_laser[big_int] = Instantiate(big_laser_FAC);
                        big_laser[big_int].transform.position = big_laser_pos[big_int].position;
                        big_laser[big_int].transform.forward = big_laser_pos[big_int].forward;
                        is_small_finished = false;
                        imsi_time = 0;
                        curtime = 0;
                        big_int = 0;
                        curAttackCount++;
                    }
                }
            }
        }
    }

    int boss_hit = 0;
    void Wait()
    {
        //아무것도 하지 않는다
        //게임 시작시 보스 대기상태 
    }

    void TempShake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;

        temp_shake_intensity = shake_intensity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("bullet"))
        {
            boss_hit++;
            if (boss_hit>=15)
            {
                mState = BossState.Demage;
                boss_hit = 0;
            }
           
        }
    }
}
