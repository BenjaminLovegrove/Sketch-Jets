using UnityEngine;
using System.Collections;

public class CameraControllerBasic : MonoBehaviour {

	public Vector3 Zaxis;
	public GameObject[] players;
	public Vector2 direction;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		Zaxis = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CenterCam();
		PullPlayers();
	}

	void CenterCam()
	{
		Vector3 cameraMove = ((players [1].transform.position - players [0].transform.position)/2.0f) + players [0].transform.position + Zaxis;
		transform.position = cameraMove;
	}

	void PullPlayers()
	{
		direction = players[0].transform.position - players[1].transform.position;

		if (Vector3.Distance (players[0].transform.position, players[1].transform.position) > 17)
		{
			players[0].rigidbody2D.AddForce (direction * -5);
			players[1].rigidbody2D.AddForce (direction * 5);
		}
	}
}
