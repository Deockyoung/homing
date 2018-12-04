using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour {

    //3 개 껐음/////////////////////////
    //크로스헤어위함
    // public GameObject crossHair;

    public float crossHairSize=2;

    public  Vector3 enemyPosition;


    public GameObject crosshair;
    public GameObject crosshairObstacle;



    // 거리값
    Vector3 originSize;

    //Obstacle 크로스헤어 거리값
    Vector3 obstacleOriginSize;

    // 보정값
    public float kSizeAdjust = 1.7f;


    //------------스피어케스트 위함-------------//
    //플레이어 위치
    private Vector3 origin;
    //플레이어 방향
    private Vector3 direction;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    //-----------------------------------------//



    private float currentHitDistnace;


    //적 위치에 대한 리스트
    public static List<GameObject> currentHitObjectList = new List<GameObject>();

    //Obstacle 위치에 대한 리스트
    public static List<GameObject> obstacleHitObjectList = new List<GameObject>();

    // Aim 된 적객체
    // - 타겟이 없으면 null 이다.
    public static GameObject currentHitObject;

    //현재 탐지된 Obstacle 
    public static GameObject obstacleHitObject;


    // Use this for initialization
    void Start () {
        // 초기의 거리값을 저장해둔다
        originSize = crosshair.transform.localScale;

        obstacleOriginSize = crosshairObstacle.transform.localScale;

    }

    // Update is called once per frame
    void Update () {


        origin = transform.position;
        direction = transform.forward;



        RaycastHit hit;
        
        //레이케스트 스피어 놓는다
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {


            //gameObject.layer == LayerMask.NameToLayer ("Player")
            //레이케스트에서 enemy 감지하면
            if (hit.transform.gameObject.tag == "Enemy")
            {

                print("Check Enemy???");

                //감지한 오브젝트(에너미)를 currentHitObject 에 넣는다
                currentHitObject = hit.transform.gameObject;

                currentHitObjectList.Add(currentHitObject);

                //거리 계산
                currentHitDistnace = hit.distance;

                //print("currentHitObjectList:" + currentHitObjectList[currentHitObjectList.Count -1] +","+ currentHitObjectList[currentHitObjectList.Count - 1].transform.position);

                //크로스헤어 활성화
                crosshair.SetActive(true);
                

                //리스트의 가장 최근 정보를 넣는다
                enemyPosition = currentHitObjectList[currentHitObjectList.Count - 1].transform.position;

                //크로스헤어에 위치정보를 넣는다.
                //crossHair.transform.position = enemyPosition;

                //크로스헤어 위치를 오브젝트 앞에 넣는다.
                //crossHair.transform.localScale = currentHitObjectList[currentHitObjectList.Count - 1].transform.localScale.normalized * crossHairSize;

                //배운것응용
                crosshair.transform.position = hit.point;
                crosshair.transform.localScale = originSize * kSizeAdjust;
                //hit.distance

            }
            else
            {
                currentHitObject = null;
            }



            ////레이케스트에서 Obstacle 감지하면-------------------gameObject.layer == LayerMask.NameToLayer ("Obstacle_Fixed")
            if (hit.transform.gameObject.tag == "Obstacle")
            {

                //감지한 오브젝트(Obstacle)를 currentHitObject 에 넣는다
                obstacleHitObject = hit.transform.gameObject;

                obstacleHitObjectList.Add(obstacleHitObject);

                //거리 계산
                currentHitDistnace = hit.distance;

                //print("currentHitObjectList:" + obstacleHitObjectList[obstacleHitObjectList.Count - 1] + "," + obstacleHitObjectList[obstacleHitObjectList.Count - 1].transform.position);

                //크로스헤어 활성화
                crosshairObstacle.SetActive(true);


                //리스트의 가장 최근 정보를 넣는다
                enemyPosition = obstacleHitObjectList[obstacleHitObjectList.Count - 1].transform.position;

                //크로스헤어에 위치정보를 넣는다.
                //crossHair.transform.position = enemyPosition;

                //크로스헤어 위치를 오브젝트 앞에 넣는다.
                //crossHair.transform.localScale = currentHitObjectList[currentHitObjectList.Count - 1].transform.localScale.normalized * crossHairSize;

                //배운것응용
                crosshairObstacle.transform.position = hit.point;
                crosshairObstacle.transform.localScale = obstacleOriginSize * kSizeAdjust;
                //hit.distance
            }


            else
            {
                obstacleHitObject = null;
            }

        }

        else
        {
            currentHitDistnace = maxDistance;
            currentHitObject = null;
        }
       
        
        //적과의 거리가 2 이하이면 크로스헤어 비활성화
        if (currentHitDistnace < 1f)
        {
            crosshair.SetActive(false);
            crosshairObstacle.SetActive(false);
        }
    }

    //기즈모 생성 위함
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistnace);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistnace, sphereRadius);

    }
}

