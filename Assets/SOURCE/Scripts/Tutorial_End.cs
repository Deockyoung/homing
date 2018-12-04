using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_End : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            //튜토리얼 모드 끄기
            //GameObject.Find("TriggerManager").GetComponent<TriggerManager>().tutorialSpace.SetActive(false);
        }

    }
}
