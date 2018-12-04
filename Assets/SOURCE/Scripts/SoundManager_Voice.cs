using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager_Voice : MonoBehaviour
{

 

    public int voiceNum;

    public AudioSource[] playerAudios;
    public AudioClip[] sounds;

    public static bool isPlaying;

    void Start()
    {
        isPlaying = true;
        playerAudios = this.gameObject.GetComponents<AudioSource>();
    }




    void Update()
    {
        if (isPlaying)
        {
            switch (voiceNum)
            {
                case 0:
                    isPlaying = false;
                    print("VoiceNum:" + voiceNum);
                    playerAudios[0].clip = sounds[voiceNum];
                    playerAudios[0].PlayOneShot(sounds[voiceNum]);
                    break;
                case 1:
                    isPlaying = false;
                    print("VoiceNum:" + voiceNum);
                    playerAudios[0].clip = sounds[voiceNum];
                    playerAudios[0].PlayOneShot(sounds[voiceNum]);
                    break;

                case 2:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 3:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 4:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 5:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 6:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 7:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 8:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 9:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 10:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 11:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 12:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 13:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 14:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

                case 15:
                    isPlaying = false;
                    playerAudios[0].clip = sounds[(int)voiceNum];
                    playerAudios[0].PlayOneShot(sounds[(int)voiceNum]);
                    break;

            }
        }

    }
}
