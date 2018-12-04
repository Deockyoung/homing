using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{



    //총알 오브젝트
    public GameObject leftBulletFactory;
    public GameObject rightBulletFactory;



    //오브젝트 풀
    GameObject[] bulletPoolLeft;
    GameObject[] bulletPoolRight;

    //총알갯수
    int bulletCount = 200;

    //리스트에 넣을 총알
    public static List<GameObject> deactiveListLeft = new List<GameObject>();
    public static List<GameObject> deactiveListRight = new List<GameObject>();

    //총쏠때 카운트(딜레이)
    float leftShotCount;
    float rightShotCount;
    public float bulletTimeCount = 0.07f;

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


    //오큘러스 컨트롤러에 달린 큐브 가져오기
    public Transform leftHand;
    public Transform rightHand;

    //총알 만들어질 오브젝트
    public Transform fireLeft;
    public Transform fireRight;

    //터렛 움직임 
    public GameObject turretLeft;
    public GameObject turretRight;

    //터렛이 바라볼 큐브
    public GameObject leftHandFront;
    public GameObject rightHandFront;

    RaycastHit leftHitInfo;
    RaycastHit rightHitInfo;


    // Use this for initialization
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


    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rot = turretLeft.transform.localRotation.eulerAngles;
       
    


        //turretLeft.transform.LookAt(leftHandFront.transform);
        //turretRight.transform.LookAt(rightHandFront.transform);

        //rot.x = Mathf.Clamp(rot.x, -180, 180);
        //rot.y = Mathf.Clamp(rot.y, -180, 180);

        //turretLeft.transform.localRotation = Quaternion.Euler(rot);


        rightShotCount += Time.deltaTime;
        leftShotCount += Time.deltaTime;
        //왼쪽버튼을 누르면 총을쏜다!! (에너미 공격용)
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            //시간이 흐른다(총 딜레이위함)

            if (deactiveListLeft.Count > 0 && leftShotCount > bulletTimeCount)
            {


                //deactiveList의 첫번째 총알을 bullet 에 넣는다
                GameObject bulletLeft = deactiveListLeft[0];




                //총 사운드 플레이
                SoundManager.Instance.Play(SoundManager.Sounds.Fire);
                //컨트롤러L 진동
                OVRHaptics.LeftChannel.Preempt(clip);

                //컨트롤러R 진동
                OVRHaptics.RightChannel.Preempt(clip);

                //파티클 L
                leftBulletParticle.Stop();
                leftBulletParticle.Play();




                // 내가 방아쇠를 당겼는데
                // 적이 있으면 적 방향으로 발사
                // - CheckEnemy 에서 타겟된 적이 있으면 그리로 발사
                // 그렇지 않으면
                // - 적이 없으면 그냥 정면으로 발사

                //총알 활성화 시킨다.
                bulletLeft.SetActive(true);

                //총알은 총 앞에 생성한다.
                bulletLeft.transform.position = fireLeft.transform.position;
                bulletLeft.transform.forward = leftHand.forward;
                //bulletLeft.transform.localScale = Vector3.one;

                BulletForBossLeft bfbl = bulletLeft.GetComponent<BulletForBossLeft>();
                if (bfbl != null)
                {
                    bfbl.dirForwardNormalized = leftHand.forward.normalized;
                }
                //리스트에서 제거한다.
                deactiveListLeft.RemoveAt(0);
                //딜레이 위한 카운트 초기화



                leftShotCount = 0;



            }
        }






        //오른손버튼을 누르면 총을쏜다!! (에너미 공격용)
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //시간이 흐른다(총 딜레이위함)

            if (deactiveListRight.Count > 0 && rightShotCount > bulletTimeCount)
            {

                //deactiveList의 첫번째 총알을 bullet 에 넣는다


                GameObject bulletRight = deactiveListRight[0];



                //총 사운드 플레이
                SoundManager.Instance.Play(SoundManager.Sounds.Fire);
                //컨트롤러L 진동
                OVRHaptics.LeftChannel.Preempt(clip);

                //컨트롤러R 진동
                OVRHaptics.RightChannel.Preempt(clip);


                //파티클 R
                rightBulletParticle.Stop();
                rightBulletParticle.Play();


                // 내가 방아쇠를 당겼는데
                // 적이 있으면 적 방향으로 발사
                // - CheckEnemy 에서 타겟된 적이 있으면 그리로 발사
                // 그렇지 않으면
                // - 적이 없으면 그냥 정면으로 발사



                //총알 활성화 시킨다.
                bulletRight.SetActive(true);

                //총알은 총 앞에 생성한다.
                bulletRight.transform.position = fireRight.transform.position;
                //bulletRight.transform.localScale = Vector3.one;
                bulletRight.transform.forward = rightHand.forward;

                BulletForBossRight bfbl = bulletRight.GetComponent<BulletForBossRight>();
                if (bfbl != null)
                {
                    bfbl.dirForwardNormalized = rightHand.forward.normalized;
                }

                //리스트에서 제거한다.
                deactiveListRight.RemoveAt(0);

                rightShotCount = 0;


            }
        }









        /////////////////////레이케스트 공격용///////////////////////
        //if (Physics.Raycast(leftRay, out leftHitInfo))
        //{
        //    print("왼쪽 레이케스트?");
        //    Debug.DrawRay(leftRay.origin, leftRay.direction * 10000, Color.red);

        //    //컨트롤러의 정면으로 총알을 발사!


        //    if (leftHitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //    {
        //        print("LeftHand 에너미 발견");

        //        //leftHitInfo.transform.GetComponent<Drone>().Damage();


        //    }
        //    else
        //    {

        //    }


        //}


        //if (Physics.Raycast(rightRay, out rightHitInfo))
        //{
        //    print("오른쪽 레이케스트?");
        //    Debug.DrawRay(rightRay.origin, rightRay.direction * 10000, Color.blue);






        //    if (rightHitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //    {
        //        print("RightHand 에너미 발견");

        //        //rightHitInfo.transform.GetComponent<Drone>().Damage();

        //    }
        //    else
        //    {

        //    }

        //}
        ///////////////////////레이케스트 공격용///////////////////////


    }
}
