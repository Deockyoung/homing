using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    //레이케이스 스피어를정면에 쏘고 일정범위 앞에 에너미가 있으면 미사일을 발사한다
    //감지한다
    //총알을 양쪽 날개에서 5개씩 발사한다




    public static GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;



    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistnace;
    

    

    float EnemyBulletTime = 0;



    //총알 오브젝트
    public GameObject FriendsbulletFactory;
    GameObject[] FriendsBulletPool;
    int bulletCount = 10;
    public Transform fireLeft;
    public Transform fireRight;


    //총알에대한 리스트
    public static List<GameObject> FriendsDeactiveList = new List<GameObject>();

    //적 위치에 대한 리스트
    public static List<GameObject> currentHitObjectList = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        //originSize = crosshair.localScale;

        //총알 갯수만큼 만들기
        FriendsBulletPool = new GameObject[bulletCount];
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(FriendsbulletFactory);

            FriendsBulletPool[i] = bullet;

            FriendsDeactiveList.Add(bullet);

            bullet.SetActive(false);
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;

        RaycastHit hit;


        //레이케스트 스피어 놓는다
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            
            //레이케스트에서 enemy 감지하면
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {

                //감지한 오브젝트(에너미)를 currentHitObject 에 넣는다
                currentHitObject = hit.transform.gameObject;

                currentHitObjectList.Add(currentHitObject);


                //거리 계산하나 지금 필요없음
                //currentHitDistnace = hit.distance;

                


                //발사 코루틴 호출
                StartCoroutine(FireEnemy());


            }
        }


        else {
            currentHitDistnace = maxDistance;
            currentHitObject = null;
        }
        
    }
    

    IEnumerator FireEnemy()
    {

        //|| FriendsDeactiveList.Count > 0

        //특정 조건이 만족할때까지 반복(while)
        
        for (int i =0; i<2 ; i++)
        {
            //if (FriendsDeactiveList.Count > 0)
            //{
                GameObject bullet = FriendsDeactiveList[0];


                bullet.transform.position = fireLeft.position;
                bullet.SetActive(true);
                FriendsDeactiveList.RemoveAt(0);


                //bullet.transform.position = fireRight.position;
                //bullet.SetActive(true);
                //FriendsDeactiveList.RemoveAt(0);

            //}
        
           
            yield return null;
        }

    

    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistnace);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistnace, sphereRadius);

    }



}
