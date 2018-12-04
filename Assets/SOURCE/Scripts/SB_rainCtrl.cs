using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_rainCtrl : MonoBehaviour {

    public bool isEnter = false;
    SB_stone_rain[] child_scr;
    int index = 0;
    float curtime;
    public float delayTime =2;
	// Use this for initialization
	void Start () {

        child_scr = transform.GetComponentsInChildren<SB_stone_rain>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(isEnter)
        {
            if (index < child_scr.Length)
            {
                curtime += Time.deltaTime;
                if(curtime> delayTime)
                {
                    Play_Rain();
                }
            }
        }
	}

    void Play_Rain()
    {
        child_scr[index].isfall = true;
        index++;
        curtime = 0;
    }
}
