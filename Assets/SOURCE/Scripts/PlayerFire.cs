using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 사용자의 Fire1 버튼이 클릭되면 총을 발사한다.
public class PlayerFire : MonoBehaviour
{



    //총알 오브젝트
    public GameObject leftBulletFactory;

    public GameObject rightBulletFactory;

    //미사일 오브젝트
    public GameObject missileFactory;


    //오브젝트 풀
    GameObject[] bulletPoolLeft;
    GameObject[] bulletPoolRight;

    GameObject[] missilePool;


    //미사일갯수
    int missileCount = 50;
    //미사일 생성 위치
    public Transform[] missilePos;



    //총알갯수
    int bulletCount = 200;
    //총알 생성 위치
    public Transform fireLeft;
    public Transform fireRight;

    //리스트에 넣을 총알
    public static List<GameObject> deactiveListLeft = new List<GameObject>();
    public static List<GameObject> deactiveListRight = new List<GameObject>();

    //리스트에 넣을 미사일
    public static List<GameObject> deactiveListMissile = new List<GameObject>();


    //총쏠때 카운트(딜레이)
    float leftShotCount;
    float rightShotCount;
    public float bulletTimeCount = 0.07f;


    public float missileTimeCount = 0.07f;

    //컨트롤러 진동 위한것
    public AudioClip viv;

    //총 쏠때마다 총구 좌우 파티클 넣기
    public ParticleSystem leftBulletParticle;
    public ParticleSystem rightBulletParticle;

    //총구 애니메이션 넣기
    public Animator rightAnim;
    public Animator leftAnim;

    //컨트롤러 진동
    OVRHapticsClip clip;

    //미사일 딜레이
    float missileDelay;
    float missileDelayCount = 1f;

    int i=0;

    void Start()
    {
        //컨트롤러 진동
        clip = new OVRHapticsClip(viv);
        //총알들을 자식으로 넣기위함
        GameObject BulletPools = new GameObject("BulletPools");
        //총알 갯수만큼 만들기
        bulletPoolLeft = new GameObject[bulletCount];
        bulletPoolRight = new GameObject[bulletCount];


        //미사일ㅇ르 자식으로 넣기
        GameObject MissilePools = new GameObject("MissilePools");
        //미사일 갯수만큼 만들기
        missilePool = new GameObject[bulletCount];



        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(leftBulletFactory, BulletPools.transform);

            bulletPoolLeft[i] = bullet;

            deactiveListLeft.Add(bullet);

            bullet.SetActive(false);
        }

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(rightBulletFactory, BulletPools.transform);

            bulletPoolRight[i] = bullet;

            deactiveListRight.Add(bullet);

            bullet.SetActive(false);
        }


        for (int i = 0; i < missileCount; i++)
        {
            GameObject missile = Instantiate(missileFactory, MissilePools.transform);

            missilePool[i] = missile;

            deactiveListMissile.Add(missile);

            missile.SetActive(false);
        }


    }
    
    void Update()
    {
        
        //왼쪽버튼을 누르면 총을쏜다!! (에너미 공격용)
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            //시간이 흐른다(총 딜레이위함)
            leftShotCount += Time.deltaTime;
            if (deactiveListLeft.Count > 0 && leftShotCount > bulletTimeCount)
            {
                //총 애니메이션
                leftAnim.SetTrigger("Fire_Left");
                rightAnim.SetTrigger("Fire_Right");

                //deactiveList의 첫번째 총알을 bullet 에 넣는다
                GameObject bulletLeft = deactiveListLeft[0];

                GameObject bulletRight = deactiveListRight[0];

                //체크된 에너미가 있다면? Bullet의 타겟에 넣는다.
                if (CheckEnemy.currentHitObject)
                {
                    bulletLeft.GetComponent<BulletLeft>().target = CheckEnemy.currentHitObject.transform;
                    bulletRight.GetComponent<BulletRight>().target = CheckEnemy.currentHitObject.transform;
                }
                    
                //총 사운드 플레이
                SoundManager.Instance.Play(SoundManager.Sounds.Fire);
                //컨트롤러L 진동
                OVRHaptics.LeftChannel.Preempt(clip);

                //컨트롤러R 진동
                OVRHaptics.RightChannel.Preempt(clip);

                //파티클 L
                leftBulletParticle.Stop();
                leftBulletParticle.Play();

                //파티클 R
                rightBulletParticle.Stop();
                rightBulletParticle.Play();


                // 내가 방아쇠를 당겼는데
                // 적이 있으면 적 방향으로 발사
                // - CheckEnemy 에서 타겟된 적이 있으면 그리로 발사
                // 그렇지 않으면
                // - 적이 없으면 그냥 정면으로 발사

                //총알은 총 앞에 생성한다.
                bulletLeft.transform.position = fireLeft.position;
                //총알 활성화 시킨다.
                bulletLeft.SetActive(true);
                //리스트에서 제거한다.
                deactiveListLeft.RemoveAt(0);
                //딜레이 위한 카운트 초기화
        



                //총알은 총 앞에 생성한다.
                bulletRight.transform.position = fireRight.position;
                //총알 활성화 시킨다.
                bulletRight.SetActive(true);
                //리스트에서 제거한다.
                deactiveListRight.RemoveAt(0);

                leftShotCount = 0;


            }
        }


        //r 컨트롤러 슛 누른다
        //5개의 미사일 한번에 발사한다
        //5개의 미사일 생성
        //생성된 미사일은 타겟으로 이동한다

        


        //미사일 카운트 하기 위함
        rightShotCount += Time.deltaTime;
        missileDelay += Time.deltaTime;
        //오른쪽버튼 누르면 미사일쏜다 ( obstacle 공격용)
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            

            if (deactiveListMissile.Count > 0 && rightShotCount > missileTimeCount)
            {
                
                 
                 for (i =0; i<1; i++)
                {
                    //deactiveList의 첫번째 총알을 bullet 에 넣는다
                    GameObject missile = deactiveListMissile[0];



                    //체크된 obstacle 있다면? Missile 타겟에 넣는다.
                    //if (CheckEnemy.obstacleHitObject)
                      //  missile.GetComponent<Missile>().missileTarget = CheckEnemy.obstacleHitObject.transform;




                    //마사일 생성될 위치 설정
                    missile.transform.position = missilePos[i].position;
                    //미사일 활성화 시킨다.
                    missile.SetActive(true);
                    //리스트에서 제거한다.
                    deactiveListMissile.RemoveAt(0);
                    //딜레이 위한 카운트 초기화

                    missileDelay = 0;
                }  
                    

              
                    

                 
                 
                //컨트롤러L 진동
                OVRHaptics.LeftChannel.Preempt(clip);

                //컨트롤러R 진동
                OVRHaptics.RightChannel.Preempt(clip);
                
                rightShotCount = 0;


            }

        }









        /////////////테스트 위함 (마우스클릭으로 발사)///////////
        //if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        //{

        //    //진동효과 넣기
        //    //OVRHapticsClip clip = new OVRHapticsClip(viv);
        //    //OVRHaptics.RightChannel.Preempt(clip);

        //    //사운드 Play
        //    SoundManager.Instance.Play(SoundManager.Sounds.Fire);

        //    if (deactiveList.Count > 0)
        //    {
        //        GameObject bullet = deactiveList[0];

        //        if (Input.GetButtonDown("Fire1"))
        //        {
        //            //파티클
        //            leftBulletParticle.Stop();
        //            leftBulletParticle.Play();

        //            bullet.transform.position = fireLeft.position;
        //            bullet.SetActive(true);
        //            deactiveList.RemoveAt(0);
        //        }

        //        else if (Input.GetButtonDown("Fire2"))
        //        {
        //            //파티클
        //            rightBulletParticle.Stop();
        //            rightBulletParticle.Play();

        //            bullet.transform.position = fireRight.position;
        //            bullet.SetActive(true);
        //            deactiveList.RemoveAt(0);
        //        }
        //    }
        //}
        /////////////테스트 위함 (마우스클릭으로 발사)///////////
    }
    
    public int n = 0;
    //코루틴 호출하여 5번 연속 발사함
    IEnumerator MissileFire()
    {
        // dieDelayTime 만큼 기다렸다가
        yield return new WaitForSeconds(i/2);

    }

}
