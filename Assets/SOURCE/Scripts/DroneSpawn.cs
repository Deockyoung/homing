using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Random 시간에 한번씩 Drone 을 만든다.
// random range
// drone 공장
public class DroneSpawn : MonoBehaviour {
    public float minTime = 2;
    public float maxTime = 5;
    GameObject droneFactory;

	// Use this for initialization
	void Start () {
        droneFactory = (GameObject)Resources.Load("Drone");
        Invoke("MakeDrone", Random.Range(minTime, maxTime));
	}
	
    // Drone 공장에서 drone 생성
	void MakeDrone () {
        GameObject drone = Instantiate(droneFactory);
        drone.transform.position = transform.position;
        Invoke("MakeDrone", Random.Range(minTime, maxTime));
    }
}
