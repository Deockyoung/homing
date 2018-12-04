using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public ParticleSystem psBomb;
    AudioSource sound;

    //PlayerFire에서 체크해야될 타겟
    public Transform target;

    public Transform frontCube;

    Rigidbody rb;
    TrailRenderer trail;
    Vector3 dir;

    public float bulletSpeed;


    Vector3 defaultDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        sound = psBomb.GetComponent<AudioSource>();
        defaultDir = frontCube.position - transform.position;
    }

    private void OnEnable()
    {
        //체크에너미에서의 에너미 위치값 가져온다.
        CheckEnemy position = GameObject.Find("Player").GetComponent<CheckEnemy>();
        //에너미 방향 가져온다.
        //dir = position.enemyPosition - transform.position;
        //총 쏘는순간 Dead 코루틴 발동
        defaultDir = frontCube.position - transform.position;
        StartCoroutine(DeadBullet());
    }


    void Update()
    {

        // 타겟이 있으면 타겟으로 발사
        if (target)
        {
            dir = target.position - transform.position;
            transform.position += dir.normalized * bulletSpeed * Time.deltaTime;
            transform.forward = dir.normalized;
        }
        // 아니면 정면으로 직진
        else
        {
            transform.position += defaultDir.normalized * bulletSpeed * Time.deltaTime;
            transform.forward = defaultDir.normalized;

            //frontCube.transform.Translate(transform.forward * 50 * Time.deltaTime);
            //frontCube.transform.position += Vector3.forward * 1000 * Time.deltaTime;
            //transform.forward = Vector3.forward;
        }
    }

    private void OnDisable()
    {
        //총알 값 초기화 시키기
        trail.Clear();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        dir = Vector3.zero;
        rb.Sleep();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // 폭발효과 발생
            // bomb 위치에 폭발 효과 발생 
            psBomb.transform.position = transform.position;
            psBomb.Stop();
            psBomb.Play();
            sound.Stop();
            sound.Play();


            //StartCoroutine(DeadBullet());
            gameObject.SetActive(false);
            PlayerFire.deactiveListLeft.Add(gameObject);
            PlayerFire.deactiveListRight.Add(gameObject);
        }




    }






    IEnumerator DeadBullet()
    {

        yield return new WaitForSeconds(2);


        trail.Clear();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        dir = Vector3.zero;
        rb.Sleep();



        target = null;
        gameObject.SetActive(false);
        PlayerFire.deactiveListLeft.Add(gameObject);
        PlayerFire.deactiveListRight.Add(gameObject);




    }


}
