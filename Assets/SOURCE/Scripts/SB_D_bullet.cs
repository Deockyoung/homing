using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_D_bullet : MonoBehaviour {

    public float movespeed =1.5f;
    float curtime;
    public AudioSource sound_clip;
    // Use this for initialization
    void Start () {
        if (transform.GetComponent<AudioSource>() != null)
        {
            sound_clip = GetComponent<AudioSource>();
        }
      

        if (sound_clip != null)
        {
            sound_clip.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * movespeed;
        curtime += Time.deltaTime;
        if(curtime >= 10)
        {
            Destroy(gameObject);
        }
        if(curtime>0.5f)
        {
            movespeed += 0.2f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Player"))
        {
            Destroy(gameObject);
        }
    }
}
