using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_holo : MonoBehaviour {

    //링이 반짝거리는 효과 
    //색
    public Color animColor_1;
    public  Color base_Color;
    Material my_mat;
    Shader my_shader;
	// Use this for initialization
	void Start () {
        my_mat = GetComponent<MeshRenderer>().material;
        base_Color = my_mat.GetColor("Holo_color");
    
    }
	
	// Update is called once per frame
	void Update () {

        my_mat.SetColor("Holo_color",Color.Lerp(base_Color, animColor_1, Mathf.PingPong(Time.time, 1)));
    }
}
