using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public static bool damage;

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {

            
            print("Damage!!!");
            damage = true;

            //데미지 사인
            GameObject.Find("UIManager").SendMessage("DamageSign");

   
        
          



        }



    }
}
