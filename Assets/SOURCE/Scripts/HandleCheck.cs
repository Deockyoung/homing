using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCheck : MonoBehaviour {


    public bool checkHands;
	// Use this for initialization
	void Start () {

        //튜토리얼 1번
        //utorialManager.Instance.tutorialNum = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "LeftHand" || coll.gameObject.tag == "RightHand")
        {

            checkHands = true;
         
        }
    }

    //private void OnTriggerExit(Collider collExit)
    //{
    //    if (collExit.gameObject.tag == "LeftHand" || collExit.gameObject.tag == "RightHand")
    //    {

    //        checkHands = false;
    //    }
    //}

}
