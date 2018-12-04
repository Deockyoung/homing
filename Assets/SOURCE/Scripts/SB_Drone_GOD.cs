using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Drone_GOD : MonoBehaviour {


    sSB_HomingM[] Dronescr;
    int index = 0;
    public float activeTime = 0.3f;
    public bool is_active = false;
    float curtime; 
	// Use this for initialization
	void Start () {

        Dronescr = transform.GetComponentsInChildren<sSB_HomingM>();
        for (int i = 0; i < Dronescr.Length; i++)
        {
           // Dronescr[i].gameObject.SetActive(false);
        }
	}


    private void Update()
    {
        if(is_active)
        {
            curtime += Time.deltaTime;
            if (curtime > activeTime)
            {
                Dronescr[index].gameObject.SetActive(true);
                index++;
                curtime = 0;
            }
            if(index == Dronescr.Length)
            {
                is_active = false;
                index = 0;
                curtime = 0;
            }
        }
    }
}
