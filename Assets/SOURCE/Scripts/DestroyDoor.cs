using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "missile")
        {


            SoundManager_Voice.isPlaying = true;
            GameObject.Find("SoundManager_Voice").GetComponent<SoundManager_Voice>().voiceNum = 5;
        }

    }
}
