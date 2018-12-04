using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFlight : MonoBehaviour {

    //배열로 모든 값을 가져온다
    public Transform[] flightPoints;
    public int flight_index=1;
    public float flightSpeed;
    public float changeSpeed;


    // Use this for initialization
    void Start () {
        flightPoints = GameObject.Find("flightPoints_One").GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (flight_index <= (flightPoints.Length - 1))
        {

            Vector3 dir = transform.position - flightPoints[flight_index].position;
            transform.position += dir * -1 / changeSpeed; ;
            Vector3.MoveTowards(transform.position, flightPoints[flight_index].position,flightSpeed);
            if (Vector3.Distance(transform.position, flightPoints[flight_index].position) < 0.5f)
            {
                flight_index++;
            }

        }

        //다시 돌아가는 스크립트 (필요없음)
        else if (flight_index > (flightPoints.Length - 1))
        {
            flight_index = 1;
        }

        //쳐다볼곳
        //transform.LookAt(target);

    }
}
