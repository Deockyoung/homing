using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 해당 스크립트가 GameObject 의 컴포넌트로 붙을때
// 강제로 원하는 컴포넌트를 삽입하도록 한다.
[RequireComponent( typeof(SphereCollider) )]
[RequireComponent( typeof(NavMeshAgent) )]
// Tower 쪽으로 이동
// - tower 공격
// 총알 맞으면 아프다...
// 한방에 죽는다.
// - 상태 (Idle, Move, Attack)
public class Drone : MonoBehaviour {
    enum DroneState
    {
        Idle,
        Move,
        Attack
    }
    DroneState mState;

    // - target 필요 (Tower 동적으로 찾자)
    Transform target;
    // - 공격범위
    public float attackRange;
    // - 이동속도
    public float moveSpeed = 3;
    // - NavMeshAgent 필요 (namespace)
    NavMeshAgent agent;

    // 폭발 효과 관련 속성
    GameObject explosion;
    ParticleSystem psExplosion;
    AudioSource expSound;

    // Use this for initialization
    void Start () {
        mState = DroneState.Idle;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

        target = GameObject.Find("Tower").transform;
        explosion = GameObject.Find("Explosion");
        psExplosion = explosion.GetComponent<ParticleSystem>();
        expSound = explosion.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // 목차 만들기!!! 
		switch(mState)
        {
            case DroneState.Idle:
                Idle();
                break;
            case DroneState.Move:
                Move();
                break;
            case DroneState.Attack:
                Attack();
                break;
        }
	}

    // 1. 가만히 있는다.
    // 2. 상태가 변하기 위한 transition 조건은??
    //  - IdleDelayTime 만큼 지나면 상태를 Move 로 전환
    public float idleDelayTime = 2;
    // 경과시간
    float currentTime;
    private void Idle()
    {
        // 시간 흐르게 하자
        currentTime += Time.deltaTime;
        // 만약 경과시간이 idleDelayTime 보다 커지면?
        if (currentTime > idleDelayTime)
        {
            // - 상태를 Move 로 전환
            mState = DroneState.Move;
            // - 경과시간은 초기화
            currentTime = 0;
            agent.enabled = true;
        }
    }

    // 1. target 방향으로 이동한다.
    // 2. target 과의 거리가 공격범위 안에 들어오면
    //  - 상태를 attack 으로 전환
    private void Move()
    {
        agent.destination = target.position;
        agent.speed = moveSpeed;

        // 2. target 과의 거리가 공격범위 안에 들어오면
        if(Vector3.Distance(transform.position, target.position) < attackRange)
        {
            //  - 상태를 attack 으로 전환
            mState = DroneState.Attack;
            // 공격상태로 되자마자 바로 공격 진행 하도록
            currentTime = attackDelay;
        }
    }

    // Tower한테 Damage 알리기
    // - 일정시간에 한번씩 공격
    // -> (공격 - 공격대기)
    public float attackDelay = 2;
    private void Attack()
    {
        currentTime += Time.deltaTime;
        if(currentTime > attackDelay)
        {
            currentTime = 0;
            // 공격 -> Tower 한테 Damage 알리기
        }
    }

    // player 가 공격할때 호출 된다.
    // 없애버린다.
    // 폭발효과

    public void Damage()
    {
        explosion.transform.position = transform.position;
        psExplosion.Stop();
        psExplosion.Play();
        expSound.Stop();
        expSound.Play();
        Destroy(gameObject);
    }
}
