using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            print("DDDD");
            // 2. 폭발효과 발생
            // - bomb 위치에 폭발 효과 발생 
            //psBomb.transform.position = transform.position;
            //psBomb.Stop();
            //psBomb.Play();
            //sound.Stop();
            //sound.Play();


            Destroy(collision.gameObject);

            //gameObject.SetActive(false);
            //PlayerFire.deactiveList.Add(gameObject);

        }
    }

}
