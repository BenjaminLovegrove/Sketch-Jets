using UnityEngine;
using System.Collections;

public class CameraControllerBasic : MonoBehaviour {

	public Vector3 Zaxis;
	public GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		Zaxis = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 cameraMove = ((players [1].transform.position - players [0].transform.position)/2.0f) + players [0].transform.position + Zaxis;
		transform.position = cameraMove;
	}
}
