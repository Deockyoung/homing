using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_rockGOD : MonoBehaviour {

    public GameObject rocks;
    int index;
    float currentTime;
    float createTime = 2;
    float minTime = 1f;
    float maxTime = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        index = Random.Range(1, 4);
        currentTime += Time.deltaTime;
        //만약 경과시간이 생성시간을 초과하면
        if (currentTime > createTime)
        {
            //경과시간 초기화
            currentTime = 0;
            //랜덤설정
            createTime = Random.Range(minTime, maxTime);
            //1.ENEMY 생성
            GameObject small_rock = Instantiate(rocks);
            //2.ENEMY 위치지정
            small_rock.transform.position = transform.position;
        }

    }


}
