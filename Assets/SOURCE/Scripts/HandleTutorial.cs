using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTutorial : MonoBehaviour {

    Animation anim;
    int num;
    public AnimationClip[] animCilps;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();

    }
	
	// Update is called once per frame
	void Update () {

        num = TutorialManager.Instance.tutorialNum;

        /*
        switch (num)
        {
            case 1:
                //anim.clip = animCilps[num - 1];
                //anim.Play();
                break;

            case 2:
                anim.clip = animCilps[num - 1];
                //anim.clip = anim.GetClip("HandleRight");
                Debug.Log(anim.clip.name);
                anim.Stop();
                anim.Play();                
                break;
            case 3:
                anim.clip = animCilps[num - 1];
                //anim.clip = anim.GetClip("HandleLeft");
                Debug.Log(anim.clip.name);
                anim.Stop();
                anim.Play();
                break;
            case 4:
                anim.clip = animCilps[num - 1];
                //anim.clip = anim.GetClip("HandleUp");
                Debug.Log(anim.clip.name);
                anim.Stop();
                anim.Play();
                break;
 
            case 5:
                anim.clip = animCilps[num - 1];
                //anim.clip = anim.GetClip("HandleDown");
                Debug.Log(anim.clip.name);
                anim.Stop();
                anim.Play();
                break;

            case 6:
                //anim.clip = animCilps[num - 1];
                //anim.Play();
                break;

            case 7:
                //anim.clip = animCilps[num - 1];
                //anim.Play();
                break;
        }
        */
	}
}
