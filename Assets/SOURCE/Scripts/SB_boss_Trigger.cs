using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_boss_Trigger : MonoBehaviour
{
    SB_bossManager boss_scr;

    private void Start()
    {
        boss_scr = GameObject.Find("boss").GetComponent<SB_bossManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Player"))
        {
           // boss_scr.mState = SB_bossManager.BossState.Idle;
        }
    }
}

