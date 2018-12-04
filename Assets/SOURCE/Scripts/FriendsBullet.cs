

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsBullet : MonoBehaviour
{

    public ParticleSystem psBomb;
    Rigidbody rb;
    AudioSource sound;

    public float friendBulletSpeed = 5;



    Vector3 dir;
    // Use this for initialization
    void Start()
    {
        sound = psBomb.GetComponent<AudioSource>();

        if (FindEnemy.currentHitObjectList.Count > 0)
        {

            //print("리스트:" + FindEnemy.currentHitObjectList.Count);
            dir = FindEnemy.currentHitObjectList[FindEnemy.currentHitObjectList.Count - 1].transform.position - transform.position;

        }


        //StartCoroutine(DeadBullet());
        //dir = FindEnemy.currentHitObject.transform.position - transform.position;


        //if (FindEnemy.currentHitObjectList.Count > 0)
        //{
        //    //print("리스트:" + FindEnemy.currentHitObjectList.Count);
        //    dir = FindEnemy.currentHitObjectList[0].transform.position - transform.position;

        //}





        //if (FindEnemy.currentHitObject.transform.position !=null)
        //{
        //    dir = FindEnemy.currentHitObject.transform.position - transform.position;
        //}

        //if (dir ==Vector3.zero)
        //{
        //    gameObject.SetActive(false);
        //    FindEnemy.FriendsDeactiveList.Add(gameObject);
        //}

    }
    //총알 5개 연속으로 정해진 방향으로 발사한다
    //감지된 제일 첫번째 Enemy 감지하고 총알 발사한다
    //리스트에 새로운 Enemy 감지되면 새로운 Enemy에 총알 발사한다

    


    // Update is called once per frame
    void Update()
    {






        //if (dir == Vector3.zero)
        //{
        //    gameObject.SetActive(false);
        //    FindEnemy.FriendsDeactiveList.Add(gameObject);
        //}

    
        transform.position += dir * friendBulletSpeed * Time.deltaTime;
        
        StartCoroutine(DeadBullet());

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            

            // 2. 폭발효과 발생
            // - bomb 위치에 폭발 효과 발생 
            psBomb.transform.position = transform.position;
            psBomb.Stop();
            psBomb.Play();
            sound.Stop();
            sound.Play();


            //Destroy(collision.gameObject);
            //없애지 말고 에너미에 대한 기능만 중지시켜야할듯

            
        }
        StartCoroutine(DeadBullet());
        //gameObject.SetActive(false);
        //FindEnemy.FriendsDeactiveList.Add(gameObject);
    }

    IEnumerator DeadBullet()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        FindEnemy.FriendsDeactiveList.Add(gameObject);
    }
}
