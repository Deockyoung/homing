using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFireButton : MonoBehaviour {

    public static bool EndingFireButtonOn;


    public GameObject earthMissileFactory;
    public Transform earthMissilePosition;


    public GameObject capsule;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        {
            GameObject earthMissile = Instantiate(earthMissileFactory);

            earthMissile.transform.position = earthMissilePosition.position;
            capsule.SetActive(false);
            //EarthForMissile.SetActive(true);
        }
    }
}
