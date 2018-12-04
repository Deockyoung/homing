using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{

    public BezierCurve path;
    Vector3 tempPos;

    [Range(0f, 1f)]
    public float u;

    public float speed;
    

    private void Update()
    {

        speed = HandController.friendSpeed;
        u += Time.deltaTime * speed/1000;

        transform.localPosition = path.GetPointAt(u);

        //print("transform.localPosition:" + transform.localPosition);



        transform.LookAt(path.GetPointAt(u+0.01f));

        
    }


}
