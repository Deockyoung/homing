using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_trigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Player"))
        {
            print("입력 ");
            // 플레이어라면
            transform.parent.GetComponent<SB_rainCtrl>().isEnter = true;
        }
    }
}
