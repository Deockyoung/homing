//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_HOM : MonoBehaviour {


    //곡선을 주는 미사일을 만들어보쟈ㅏ 
    public enum CurveXYZ
    {
        X,
        Y,
        xy,
        accel,
        stop
    }

    public CurveXYZ curveState;
    Transform target;
    Rigidbody rd;
    float curtime = 0;
    public float movespeed = 3;
    Vector3 dir;
    float curDistance;
    float percent = 0;
    float full_Distance;
    public float PosMagnitude = 1;
    float acOutPut;
    public float closeDistance = 30;
    public AnimationCurve POS_CURVE;
    public float acelMagnitude = 2;
    public AnimationCurve accelCV;
    float accelFloat;
    ParticleSystem ps_exp;
    TrailRenderer tr;
    float bulletTime = 0.6f;
    public GameObject bulletFactory;
    int _stateRandom = 0;
    Transform bulletPos;
    float delayDistance = 15;
    AudioSource asource;
    void Start () {
        asource = GetComponent<AudioSource>();
        rd = gameObject.GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        full_Distance = Vector3.Distance(target.position, transform.position);
        //출발 시작점 (포물선의 시작점 )
        tr = GetComponent<TrailRenderer>();
        tr.Clear();
        ps_exp = GameObject.Find("par1").GetComponent<ParticleSystem>();
        movespeed = Random.Range(50, 70);
        _stateRandom = Random.Range(0, 2);
        if(_stateRandom == 0)
        {
            curveState = CurveXYZ.X;
        }
        else if(_stateRandom == 1)
        {
            curveState = CurveXYZ.Y;
        }
        else if (_stateRandom == 2)
        {
            curveState = CurveXYZ.xy;
        }

        bulletPos = transform.GetChild(0);
    }

   
	void Update () {
;
      
            
        dir = (target.position - transform.position).normalized;
        transform.forward = dir;
        //퍼센트 구하기 --> 시작거리 /도착거리의 디스턴스값 -> 도착하면 디스턴스 값은 1이 된다
        curDistance = Vector3.Distance(target.position, transform.position);
        //퍼센트
        percent = curDistance / full_Distance;
        acOutPut = (POS_CURVE.Evaluate(percent) * PosMagnitude);

        if (curDistance > closeDistance)
        {
           // transform.position += new Vector3(dir.x+ acOutPut, dir.y + acOutPut, dir.z) * movespeed * Time.deltaTime;
            switch (curveState)
            {
                case CurveXYZ.X:
                    Xcurve();
                    break;

                case CurveXYZ.Y:
                    Ycurve();
                    break;

                case CurveXYZ.xy:
                    XYcurve();
                    break;
                case CurveXYZ.accel:
                    Accel();
                    break;
                case CurveXYZ.stop:
                    Stop_Move();
                    break;
            }
        }

        //플레이어에게 가까이 왔을 때 직선움직임 + 가속도를 붙여라 
        if (curDistance <= closeDistance)
        {
            //curveState = CurveXYZ.accel;
            accelFloat = acelMagnitude * accelCV.Evaluate(curDistance / closeDistance);
            transform.position += dir * (movespeed + accelFloat) * Time.deltaTime;
        }

        /*
        if(curDistance<= delayDistance)
        {
            curveState = CurveXYZ.stop;
        }
        */
        //총알 쏘기 
        curtime += Time.deltaTime;
        if(curtime>=bulletTime)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = bulletPos.position;
            bullet.transform.forward = bulletPos.forward;
            curtime = 0;
        }


    }

    private void Stop_Move()
    {
      //움직이지 않음
    }

    void Xcurve()
    {
        transform.position += new Vector3(dir.x + acOutPut, dir.y , dir.z) * movespeed * Time.deltaTime;
    }
    void Ycurve()
    {
        transform.position += new Vector3(dir.x , dir.y + acOutPut, dir.z) * movespeed * Time.deltaTime;
    }
    void XYcurve()
    {
        transform.position += new Vector3(dir.x + acOutPut, dir.y + acOutPut, dir.z) * movespeed * Time.deltaTime;
    }
    void Accel()
    {
        accelFloat = acelMagnitude * accelCV.Evaluate(curDistance / closeDistance);
        transform.position += dir * (movespeed + accelFloat) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Player") ||
            other.gameObject.tag.Contains("Bullet"))
        {
            ps_exp.transform.position = transform.position;
            ps_exp.Stop();
            ps_exp.Play();
            asource.Play();
            Destroy(gameObject);
        }
    }
}
