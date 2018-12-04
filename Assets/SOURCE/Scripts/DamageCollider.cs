using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {


    public bool damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy_Missile" || coll.gameObject.tag == "Enemy")
        {
            print("에너미콜리전????");
            UIManager.Instance.WarningSign();
        }

        if (coll.gameObject.tag == "Obstacle")
        {
            print("옵스타클콜리전????");
            UIManager.Instance.CautionSign();





        }


        print("Damage!!!");
        damage = true;

 

    }



    //private void OnTriggerEnter(Collision coll)
    //{
    //    if (coll.gameObject.tag == "Enemy_Missile" || coll.gameObject.tag == "Enemy")
    //    {
    //        print("에너미콜리전????");
    //        UIManager.Instance.WarningSign();
    //    }

    //    if (coll.gameObject.tag == "Obstacle")
    //    {
    //        print("옵스타클콜리전????");
    //        UIManager.Instance.CautionSign();
    //    }

    //}



}
