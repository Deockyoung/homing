using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public ParticleSystem missileBomb;
    AudioSource sound;


    Vector3 defaultDir;
    public Transform fronCube;



    Vector3 dir;
    //PlayerFire에서 체크해야될 타겟
    //미사일 타겟으로 변경해야함
    //public Transform missileTarget;


    Rigidbody rb;
    public float missileSpeed=500;
    public AnimationCurve ac;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * missileSpeed);

        sound = missileBomb.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        defaultDir = fronCube.position - transform.position;

        //체크에너미에서의 에너미 위치값 가져온다.
        //CheckEnemy position = GameObject.Find("Player").GetComponent<CheckEnemy>();
        //에너미 방향 가져온다.
        //dir = position.enemyPosition - transform.position;
        //총 쏘는순간 Dead 코루틴 발동
        StartCoroutine(DeadBullet());
    }

    Transform target;
    private void Start()
    {
        //target = missileTarget;
        
    }

    // Update is called once per frame
    void Update()
    {

        // 타겟이 있으면 타겟으로 발사
        //if (target)
        //{
        //    dir = target.position - transform.position;
        //    transform.position += dir.normalized * missileSpeed * Time.deltaTime;
        //    transform.forward = dir.normalized;
        //}
        // 아니면 정면으로 직진
        //else
        //{
            transform.position += defaultDir.normalized * missileSpeed * Time.deltaTime;
            transform.forward = defaultDir.normalized;
        //}

        


    }

    

    private void OnDisable()
    {
        //총알 값 초기화 시키기
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        dir = Vector3.zero;
        rb.Sleep();
    }



    private void OnCollisionEnter(Collision collision)
    {
        //missileBomb.transform.position = transform.position;
        //missileBomb.Stop();
        //missileBomb.Play();
        //sound.Stop();
        //sound.Play();
        //gameObject.SetActive(false);
        //PlayerFire.deactiveListMissile.Add(gameObject);
        //if (other.gameObject.tag == "Player")
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        if (collision.gameObject.tag == "Obstacle")
        {
            // 폭발효과 발생
            // bomb 위치에 폭발 효과 발생 
            missileBomb.transform.position = transform.position;
            missileBomb.Stop();
            missileBomb.Play();
            sound.Stop();
            sound.Play();


            //StartCoroutine(DeadBullet());
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            PlayerFire.deactiveListMissile.Add(gameObject);
        }



    }






    IEnumerator DeadBullet()
    {

        yield return new WaitForSeconds(8);

        //missileTarget = null;
        gameObject.SetActive(false);
        PlayerFire.deactiveListMissile.Add(gameObject);

    }






}
