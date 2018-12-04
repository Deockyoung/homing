using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int Score;
    public Text scoreText;


    public static ScoreManager Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = Score.ToString();

	}
}
