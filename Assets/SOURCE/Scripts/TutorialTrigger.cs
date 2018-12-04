using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {

    public int index;

    ParticleSystem ps_ring;
    Animator ring_anim;

    private void Start()
    {
        ps_ring = GameObject.Find("ring_ex").GetComponentInChildren<ParticleSystem>();
        ring_anim = transform.parent.GetChild(0).GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
      //  TutorialManager.Instance.tutorialNum = index;
      //  print("TutorialManager.Instance.tutorialNum:" + TutorialManager.Instance.tutorialNum);
        if(other.gameObject.tag.Contains("Player"))
        {
            ps_ring.Stop();
            ps_ring.Play();
            ring_anim.SetBool("is_ring_touch", true);
        }
    }
}
