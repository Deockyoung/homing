using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : MonoBehaviour {

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject body;
    public float shakeTimer;
    public float shakeAmount;



    bool damageInput;
    int inputFour;
    

    private void Start()
    {
    }

    void FixedUpdate()
    {



    }

    void Update()
    {
      
        //ShakeCamera(,)함수에서 설정된 시간에 따른 함수 호출
        if (shakeTimer >= 0)
        {
            //카메라 흔들릴 위치는 shakeAmount 값(할당된 범위)에 따라 랜덤으로 설정됨
            Vector2 ShakePos = UnityEngine.Random.insideUnitCircle * shakeAmount;

            //할당된 위치로 이동
            body.transform.position = new Vector3(body.transform.position.x + ShakePos.x, body.transform.position.y + ShakePos.y, body.transform.position.z);

            //시간 점점 감소함으로써 흔들림 멈춤
            shakeTimer -= Time.deltaTime;
        }

        //데미지를 받았을경우
        if (Damage.damage == true)
        {
            //할당된 범위와 시간만큼 카메라를 움직임(진동효과)
            ShakeCamera(3, 0.5f);

            //0.2f, 3f
            //카메라 움직임 끝났을시 호출됨
            EndCamShake();
        }




    }

    //지진구역 끝났을시 후촐
    private void EndCamShake()
    {
        //데미지 받는중 off로 전환
        Damage.damage = false;
    }

    //카메라 shake 할당
    public void ShakeCamera(float ShakePwr, float shakeDur)
    {

        shakeAmount = ShakePwr;
        shakeTimer = shakeDur;
    }
}