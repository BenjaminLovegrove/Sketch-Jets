using UnityEngine;
using System.Collections;

public class P2Controller : MonoBehaviour {
	
	
public float movSpd = 15.0f;
public GameObject bullet2;
public float angle;
public float fireSpeed = 0.0f;
public GameObject bltSpn;
public GameObject rocket;
public GameObject primaryWeapon;
public int numEquip = 1;


void Update () {
		
	Vector3 moveDir = new Vector3 ();
		
	moveDir.x = Input.GetAxis ("Horizontal2");
	moveDir.y = Input.GetAxis ("Vertical2");
		
	this.rigidbody2D.AddForce (moveDir.normalized * movSpd);

	float x = Input.GetAxis("RotHorizontal2");
	float y = Input.GetAxis("RotVertical2");
		
	if (x != 0.0f || y != 0.0f) {
		angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector2 (-angle + 90, 90);
	}

	//fires
	if (Input.GetButtonDown ("Fire2")) {
		Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
	}
	if (primaryWeapon == bullet2 && Input.GetButtonDown ("Switch2")) {
		primaryWeapon = rocket;
		print ("rocket equiped");
	} else if (primaryWeapon == rocket && Input.GetButtonDown ("Switch2")) {
		primaryWeapon = bullet2;
		print ("bullet equiped");
	}
}
}