using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 마우스 입력에 따라 물체를 회전시킨다.
// - 회전속도
// - 누적 회전 값
// - 회전 제약
public class CamRotate : MonoBehaviour {
    // - 회전속도
    public GameObject frontCube;
    public GameObject body;
    public float rotSpeed = 200;
    float mx;
    float my;
    public float minAngle = -100;
    public float maxAngle = 100;
    public static float vertical;
    public static float rotation;
    public static Vector3 cubeRotation;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 사용자의 마우스 입력에 따라 물체를 회전시킨다.
        // 3. 사용자의 입력 얻어야 한다.


         vertical = Input.GetAxis("Vertical");
         rotation = Input.GetAxis("Horizontal");



        // 2. 각도 (p = p0 + vt)
        mx += rotation * rotSpeed * Time.deltaTime;
        my += vertical * rotSpeed * Time.deltaTime;
     

        //mx = Mathf.Clamp(mx, minAngle, maxAngle);
       // my = Mathf.Clamp(my, minAngle, maxAngle);

        cubeRotation = new Vector3(-my, mx, 0);
        // 1. 회전시키자.
        frontCube.transform.eulerAngles = new Vector3(-my, mx, 0);
        //body.transform.eulerAngles = new Vector3(-my, mx, 0);

        //비행기도 회전시키려면
        //먼저 앞에있는 큐브를 회전시키고
        //비행기의 회전값을 점차 큐브값으로 바꾼다
        //점점 더해서 바꾼다 
        //시발제발좀!!
    }
}
