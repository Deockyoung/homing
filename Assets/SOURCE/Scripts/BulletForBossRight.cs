using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForBossRight : MonoBehaviour
{

    public ParticleSystem psBombRight;
    AudioSource soundRight;


    public Transform frontCubeRight;

    Rigidbody rbRight;
    TrailRenderer trailRight;
    Vector3 dirRight;
    [HideInInspector]
    public Vector3 dirForwardNormalized;
    private void Awake()
    {
        rbRight = GetComponent<Rigidbody>();
        trailRight = GetComponent<TrailRenderer>();
        soundRight = psBombRight.GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        //에너미 방향 가져온다.
        //dir = position.enemyPosition - transform.position;
        //총 쏘는순간 Dead 코루틴 발동
        StartCoroutine(DeadBulletRight());
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
        trailRight.Clear();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        dirRight = Vector3.zero;
        rbRight.Sleep();
    }



    private void OnCollisionEnter(Collision collision)
    {
        psBombRight.transform.position = transform.position;
        psBombRight.Stop();
        psBombRight.Play();
        soundRight.Stop();
        soundRight.Play();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            StopCoroutine("DeadBulletRight");

            ScoreManager.Instance.Score++;
            // 폭발효과 발생
            // bomb 위치에 폭발 효과 발생 
            psBombRight.transform.position = transform.position;
            psBombRight.Stop();
            psBombRight.Play();
            soundRight.Stop();
            soundRight.Play();

            Destroy(collision.gameObject);

            //StartCoroutine(DeadBullet());
            if (!PlayerShooting.deactiveListRight.Contains(gameObject))
            {
                gameObject.SetActive(false);
                PlayerShooting.deactiveListRight.Add(gameObject);
            }
        }




    }






    IEnumerator DeadBulletRight()
    {

        yield return new WaitForSeconds(2);

        if (!PlayerShooting.deactiveListRight.Contains(gameObject))
        {
            gameObject.SetActive(false);
            PlayerShooting.deactiveListRight.Add(gameObject);
        }
    }


}
