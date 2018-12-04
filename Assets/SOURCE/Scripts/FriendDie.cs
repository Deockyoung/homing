using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendDie : MonoBehaviour {

    public GameObject friendDY;


    public AudioClip damage_se;
    AudioSource audiossssss;
    public GameObject crack1;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friend2")
        {

            friendDY.SetActive(false);
                audiossssss = GetComponent<AudioSource>();

                audiossssss.PlayOneShot(damage_se);

            crack1.SetActive(true);


            }


    }


}
