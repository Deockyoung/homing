using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {
    private int numPoints = 3;
    private Vector3[] positions = new Vector3[3];


    public Transform point0;
    public Transform point1;
    public Transform point2;
    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
        //p0 - 현재 비행기 위치
        //p1 - 비행기 앞 벡터값 ( 비행기 앞에 큐브 하나 놓는다 )
        //p2 - 이동 끝난 후 큐브의 벡터값 (마지막 위치) 





        QuadraticCurve();
        

    }


    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        print("p값은?:" + p);
        return p;
    }




    void QuadraticCurve()
    {
        for(int i = 1; i < numPoints +1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
        }
    }
}
