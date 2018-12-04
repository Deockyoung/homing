using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCubeMoving : MonoBehaviour
{

    public BezierCurve path;
    Vector3 tempPos;

    [Range(0f, 1f)]
    public float u;

    public float speed;
    

    private void Update()
    {
        u += Time.deltaTime * speed/1000;

        transform.localPosition = path.GetPointAt(u);

        print("transform.localPosition:" + transform.localPosition);


        
        
    }





    /// <summary>
    /// whale이 기본적으로 헤엄치는 것을 구현
    /// 원점이 일치하게 manually position 시켜야함
    /// lastRail의 첫번째 child가 고래의 위치를 계속 따라다니도록 한다.
    /// </summary>

    //public AnimationCurve moveSpeed;
    //[Range(0.0f, 1.0f)]
    //float time;

    //public BezierCurve whaleIdle;
    //Vector3 goalPos;

    //public float playTime = 50f;

    //void Start()
    //{

    //    try
    //    {
    //        Debug.Log("연결 상태 : " + whaleIdle, gameObject);
    //    }
    //    catch
    //    {
    //        Debug.Log("연결 불량", gameObject);
    //    }


    //    StartMoving();
    //}

    //IEnumerator Moving()
    //{
    //    float t = 0;
    //    Vector3 tempPos;

    //    while (t < 0.99f)
    //    {

    //        // 시간을 흐르게 한다.
    //        time += Time.deltaTime;

    //        // 0에서 1사이의 수로 바꾼다.
    //        t = moveSpeed.Evaluate(time / playTime);

    //        // 위치 이동 전에 현재 위치를 저장한다.
    //        tempPos = transform.position;

    //        // 위치 이동을 한다.
    //        transform.position = whaleIdle.GetPointAt(t);

    //        // 방향 바꾸기 ( 이전 위치와 현재 위치를 통해서 방향을 바꾼다.)
    //        //이전방향을 잘 둬야 방향전환이 자유로움
    //        transform.forward = transform.position - tempPos;


    //        yield return null;
    //    }

    //    time = 0f;
    //    StartCoroutine("Moving");
    //}

    //public void StartMoving()
    //{
    //    StartCoroutine("Moving");
    //}

    //public void StopMoving()
    //{
    //    StopCoroutine("Moving");
    //}
}
