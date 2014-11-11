using UnityEngine;
using System.Collections;

public class CameraControllerBasic : MonoBehaviour {

	public GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//Get player position and move camera to it
		//Will change this to be p1 - p2 for inbetween once p2 is implemented
		if (players [1] != null){
			Vector3 cameraMove = new Vector3 ((players [0].transform.position.x, players [0].transform.position.y, transform.position.z) - (players [1].transform.position.x, players [1].transform.position.y, transform.position.z));
			transform.position = cameraMove;
		} else {
			Vector3 cameraMove = new Vector3 (players [0].transform.position.x, players [0].transform.position.y, transform.position.z);
			transform.position = cameraMove;
		}


	}
}
