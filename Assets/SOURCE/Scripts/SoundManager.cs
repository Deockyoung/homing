using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{


// Scene 에서 제공되는 모든 Sound 들을 관리 한다.
// audio 재생이 필요하면 SoundManager 를 통해서 한다.

// 각각의 상태 설정
// - IDLE(숨소리) -> 나중에 추가 구현 
// - Walk(또각또각 걷는 사운드) -> 프로토타입
// - Shot(펑!----) -> 프로토타입 
// - reload(철커덕) -> 프로토타입

// 사운드 재생을 하고싶다.
// 1. 재생하고 싶다.
// 2. audio source 가 필요
// 3. audio clip 필요


// 배경 오디오 소스 설정 정하기 //
// [0] 배경음악
// [1] 움직임 (풀걷기, 돌걷기, 풀뛰기, 돌뛰기)
// [2] 총관련 (샷) 
// [3] 총관련 (장전)
        // [0]은 기본재생, [2]와 [3]은 동시에 나와야 함.
        // [0], [1], [2], [3] 이 동시에 나올 수 있어야 함.
       


    bool isBG;

    // 필요한 상태별 클립 선언해준다 (성혜)
    public enum Sounds
    {
        BG,

        FlightEngine,
        FlightDie,

        FlightSpeedUp,
        FlightSpeedDown,
        FlightWarp,
        
        Explosion,

        Fire,
        FireMissile,
        Voice,

        Click, 
        Text
    }

    // 배열 선언 (다중트랙)
    public AudioSource[] playerAudios;
    public AudioClip[] sounds;

    // 다른 스크립트에서 가져다가 쓸 수 있도록 싱글톤으로 만든다. 
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        playerAudios = this.gameObject.GetComponents<AudioSource>();
        Play(SoundManager.Sounds.BG);
    }

    private void Update()
    {

    }

    public void Play(Sounds s) // Sound는 위에 enum 선언했던 것 
    {
        // [0] 배경음악 
        if (s == Sounds.BG)
        {
            playerAudios[0].clip = sounds[(int)s];
            playerAudios[0].Play();
            playerAudios[0].loop = true;
        }

        // [1] 엔진소리 
        else if (s == Sounds.FlightEngine || s == Sounds.FlightDie)
        {
            playerAudios[1].clip = sounds[(int)s];
            playerAudios[1].Play();
            playerAudios[1].loop = true;
        }



        // [2] FlightSpeedUp,FlightSpeedDown,FlightWarp,FlightDie,
        else if (s == Sounds.FlightSpeedUp || s == Sounds.FlightSpeedDown || s == Sounds.FlightWarp)
        {
            // Play 되지 않고 있으면 
            // -> 한번만 재생해야 한다. 이유는?? 계속 Play 함수를 호출하면 사운드가 겹쳐서 드드드드 되기때문...
            // -> 재생 안되어 있을때 한번만 실행하기
            // 1. walking sound 재생???
            // 2. 걷는 중인데 사운드가 재생이 안되어 있으면 재생하라            
            if (playerAudios[2].isPlaying == false)
            {
                // 클립에 소스를 넣고 플레이해라
                playerAudios[2].clip = sounds[(int)s];
                playerAudios[2].Play();
            }
        }

        else if (s == Sounds.Explosion)
        {
            playerAudios[3].clip = sounds[(int)s];
            playerAudios[3].Play();
        }

        else if (s == Sounds.Fire)
        {

            playerAudios[4].clip = sounds[(int)s];
            playerAudios[4].Play();
        }

        else if (s == Sounds.FireMissile)
        {
            playerAudios[5].clip = sounds[(int)s];
            playerAudios[5].Play();
        }

        else if (s == Sounds.Click || s == Sounds.Text)
        {
            // Play 되지 않고 있으면 
            // -> 한번만 재생해야 한다. 이유는?? 계속 Play 함수를 호출하면 사운드가 겹쳐서 드드드드 되기때문...
            // -> 재생 안되어 있을때 한번만 실행하기
            // 1. walking sound 재생???
            // 2. 걷는 중인데 사운드가 재생이 안되어 있으면 재생하라            
            if (playerAudios[6].isPlaying == false)
            {
                // 클립에 소스를 넣고 플레이해라
                playerAudios[6].clip = sounds[(int)s];
                playerAudios[6].Play();
            }
        }
    }

    // 멈추면 walk 사운드를 꺼준다.
    public void WalkStop()
    {
        playerAudios[1].Stop();
    }
    
    public void Stop()
    {
        if (isBG)
        {
            playerAudios[0].Stop();
        }
        else
        {
            playerAudios[1].Stop();
        }
    }
}
