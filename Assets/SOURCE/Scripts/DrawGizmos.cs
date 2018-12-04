using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour {

    public List<Transform> path = new List<Transform>();

	// Use this for initialization
	void Start () {

        //path = this.gameObject.GetComponentsInChildren<Transform>();
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        for(int i= 0; i < path.Count-1; i++)
        {
            Gizmos.DrawLine(path[i].position, path[i + 1].position);
        }
    }


}
