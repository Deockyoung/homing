using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_trig_2 : MonoBehaviour {
    SB_SLOW[] slow_scr;

    bool imsi = false;
    float curtime;
    int index = 0;
	// Use this for initialization
	void Start () {

        slow_scr = transform.root.GetComponentsInChildren<SB_SLOW>();

    }
	
	// Update is called once per frame
	void Update () {
		
     
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Player"))
        {
            //imsi = true;
            for (int i = 0; i < slow_scr.Length; i++)
            {
                slow_scr[i].istest = true;
            }
        }
    }
}
