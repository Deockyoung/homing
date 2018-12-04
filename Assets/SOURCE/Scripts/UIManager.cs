using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


    //데미지 이미지 위함
    public GameObject warningSign;
    public GameObject cautionSign;


    public static UIManager Instance;

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

		
	}

    public void WarningSign()
    {
        warningSign.SetActive(true);
        StartCoroutine(WarningSignOff());
    }

    public void CautionSign()
    {
        cautionSign.SetActive(true);
        StartCoroutine(CautionSignOff());
    }


    IEnumerator WarningSignOff()
    {
        yield return new WaitForSeconds(3);

        warningSign.SetActive(false);

    }



    IEnumerator CautionSignOff()
    {
        yield return new WaitForSeconds(3);

        cautionSign.SetActive(false);

    }
}
