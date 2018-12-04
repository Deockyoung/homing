using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// 사용자의 입력에따라(상하좌우 점프) 이동하게 한다.
// - 이동속도
// 1. 이동하게 한다.
// 2. 방향
// 3. 입력으로부터
public class PlayerMove : MonoBehaviour {
    // - 이동속도
    public float moveSpeed = 100;
    public float rotationSpeed = 5;
    public GameObject body;
    public GameObject frontCube;

    CharacterController cc;
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame

    float vertical;
    float rotation;
	void Update () {
        




        float translation = Input.GetAxis("Jump") * moveSpeed;


        //float vertical = Input.GetAxis("Vertical");

        //큐브 회전값을 받아온다
         Vector3 cubeRotation = CamRotate.cubeRotation;
        //print("cubeRotation" + cubeRotation);


        Vector3 dir = new Vector3(0, 0, translation);


        ////현재 각도에서 받아온 회전값까지 점차 더한다

        //전진버튼을 눌렀을때
        if (Input.GetKey(KeyCode.Space)){


            //p = p0 + vt
            transform.forward += frontCube.transform.forward * rotationSpeed * Time.deltaTime;


            //transform.rotation = Quaternion.RotateTowards(transform.rotation,frontCube.transform.rotation  , 3);
            //큐브각도와 내 각도가 맞을때까지 각도를 올려라



            //if (transform.rotation.x != cubeRotation.x)
            //{
            //    print("22222");
            //    rotation *= Time.deltaTime;
            //}
            //if(transform.rotation.y != cubeRotation.y)
            //{
            //    print("33333");

            //    vertical *= Time.deltaTime;
            //}
            //transform.Rotate(-vertical, rotation, 0);
            //dir = frontCube.transform.TransformDirection(dir);
            cc.Move(transform.forward * moveSpeed * Time.deltaTime);


        }


        //translation *= Time.deltaTime;


        //transform.Translate(0, 0, translation);



        //Vector3 dir = new Vector3(vertical, rotation,0);











        //body.transform.Rotate(0, 0 , -rotation);

        //상하 -90~90
        //좌우 -90~90

    }
}
