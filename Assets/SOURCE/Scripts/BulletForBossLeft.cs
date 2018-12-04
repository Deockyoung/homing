using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForBossLeft : MonoBehaviour
{

    public ParticleSystem psBombLeft;
    AudioSource soundLeft;


    public Transform frontCubeLeft;

    Rigidbody rbLeft;
    TrailRenderer trailLeft;
    Vector3 dirLeft;

    [HideInInspector]
    public Vector3 dirForwardNormalized;

    private void Awake()
    {
        rbLeft = GetComponent<Rigidbody>();
        trailLeft = GetComponent<TrailRenderer>();
        soundLeft = psBombLeft.GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        //체크에너미에서의 에너미 위치값 가져온다.

        //에너미 방향 가져온다.
        //dir = position.enemyPosition - transform.position;
        //총 쏘는순간 Dead 코루틴 발동
        StartCoroutine(DeadBulletLeft());
    }


    void Update()
    {
        transform.forward = Vector3.forward;
        transform.Translate(dirForwardNormalized * 1000 * Time.deltaTime);

        //frontCube.transform.Translate(transform.forward * 50 * Time.deltaTime);
        //frontCube.transform.position += Vector3.forward * 1000 * Time.deltaTime;
        //transform.forward = Vector3.forward;

    }

    private void OnDisable()
    {
        //총알 값 초기화 시키기
        trailLeft.Clear();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        dirLeft = Vector3.zero;
        rbLeft.Sleep();
    }



    private void OnCollisionEnter(Collision collision)
    {

        psBombLeft.transform.position = transform.position;
        psBombLeft.Stop();
        psBombLeft.Play();
        soundLeft.Stop();
        soundLeft.Play();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            StopCoroutine("DeadBulletLeft");

            ScoreManager.Instance.Score++;
            // 폭발효과 발생
            // bomb 위치에 폭발 효과 발생 
            psBombLeft.transform.position = transform.position;
            psBombLeft.Stop();
            psBombLeft.Play();
            soundLeft.Stop();
            soundLeft.Play();

            Destroy(collision.gameObject);
            //StartCoroutine(DeadBullet());
            if (!PlayerShooting.deactiveListLeft.Contains(gameObject))
            {
                gameObject.SetActive(false);
                PlayerShooting.deactiveListLeft.Add(gameObject);
            }
        }




    }






    IEnumerator DeadBulletLeft()
    {
        yield return new WaitForSeconds(2);

        if (!PlayerShooting.deactiveListLeft.Contains(gameObject))
        {
            gameObject.SetActive(false);
            PlayerShooting.deactiveListLeft.Add(gameObject);
        }
    }


}
