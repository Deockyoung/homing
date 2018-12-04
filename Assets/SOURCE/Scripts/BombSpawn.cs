using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bomb 이 현재 비활성화 되어 있다면
// bomb 을 일정 시간후에 다시 활성화 시키도록 하자
public class BombSpawn : MonoBehaviour {
    public float activeTime = 1.5f;
    public GameObject bomb;

    public static BombSpawn Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // 1. bomb 비활성화 시킨다.
    // 2. activeTime 후에 bomb 을 활성화 시킨다.
    public void ActiveBomb()
    {
        bomb.SetActive(false);
        Invoke("AliveBomb", activeTime);
    }

    void AliveBomb()
    {
        // 자동으로 날아간다.
        // rigidbody
        //  - rigidbody 꺼져있어야...
        bomb.GetComponent<Rigidbody>().isKinematic = true;
        //  - rigidbody velocity ?? 0
        bomb.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bomb.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        bomb.transform.position = transform.position;
        bomb.transform.rotation = Quaternion.identity;
        bomb.SetActive(true);
    }
}
