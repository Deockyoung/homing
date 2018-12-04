using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_skill2_bullet : MonoBehaviour {


    ParticleSystem ps;
    public ParticleSystem exp;
    Transform target;
    // Use this for initialization
    public float movespeed = 2;
    Transform exp_pos;
    AudioSource[] play_source;
    float lifeTime;
    int temp_int = 0; 
	void Start () {
        temp_int = Random.Range(0, 2);
        play_source = GetComponents<AudioSource>();
        play_source[temp_int].Play();
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Stop();
        ps.Play();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       // exp = GameObject.Find("skilL2_exp").GetComponent<ParticleSystem>();
        exp_pos = GameObject.Find("exp_pos").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * movespeed;

        lifeTime += Time.deltaTime;
        if(lifeTime >7)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Player"))
        {

            exp.transform.position = exp_pos.transform.position;
            exp.Stop();
            exp.Play();
        
        }
        
    }
}
