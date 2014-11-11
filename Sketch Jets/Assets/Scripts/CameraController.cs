using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float movSpd = 0.1f;
	public float angleP1;
	public float angleP2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Get both players controller movement and move camera
		Vector3 moveDir = new Vector3 ();

		moveDir.x = Input.GetAxis ("Horizontal1");
		moveDir.y = Input.GetAxis ("Vertical1");

		this.transform.Translate (moveDir.normalized * movSpd);

		Vector3 moveDir2 = new Vector3 ();
		
		moveDir2.x = Input.GetAxis ("Horizontal2");
		moveDir2.y = Input.GetAxis ("Vertical2");
		
		this.transform.Translate (moveDir2.normalized * movSpd);


		//Set rotation variables if required
		//player1 Rotation
		float x1 = Input.GetAxis("RotHorizontal1");
		float y1 = Input.GetAxis("RotVertical1");
		
		if (x1 != 0.0f || y1 != 0.0f) {
			angleP1 = Mathf.Atan2 (y1, x1) * Mathf.Rad2Deg;
			// Do something with the angle here.
			}

		//player2 Rotation
		float x2 = Input.GetAxis("RotHorizontal2");
		float y2 = Input.GetAxis("RotVertical2");
			
		if (x2 != 0.0f || y2 != 0.0f) {
			angleP2 = Mathf.Atan2(y2, x2) * Mathf.Rad2Deg;
			// Do something with the angle here.
			}
	}
}
