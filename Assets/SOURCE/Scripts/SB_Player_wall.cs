using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Player_wall : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy")||
           other.tag.Contains("bullet")||
           other.gameObject.layer== LayerMask.NameToLayer("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
