using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend_Second_Kill : MonoBehaviour
{


    public ParticleSystem friendKillParticle;
    AudioSource sound;
    // Use this for initialization
    void Start()
    {

        sound = friendKillParticle.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FriendTwo")
        {
            {
                // 폭발효과 발생
                // bomb 위치에 폭발 효과 발생 
                friendKillParticle.transform.position = transform.position;
                friendKillParticle.Stop();
                friendKillParticle.Play();
                sound.Stop();
                sound.Play();

                //친구비행기 죽이기
                Destroy(collision.gameObject);
            }

        }
    }
}

