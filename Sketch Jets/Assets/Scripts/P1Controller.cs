using UnityEngine;
using System.Collections;

public class P1Controller : MonoBehaviour {

	
public float movSpd = 15.0f;
public GameObject bullet;
public float angle;
public float fireSpeed = 0.0f;
public GameObject bltSpn;
public GameObject rocket;
public GameObject primaryWeapon;
public int numEquip = 1;


void Update () {
		
	Vector3 moveDir = new Vector3 ();
		
	moveDir.x = Input.GetAxis ("Horizontal1");
	moveDir.y = Input.GetAxis ("Vertical1");
		
	this.rigidbody2D.AddForce (moveDir.normalized * movSpd);

	float x = Input.GetAxis("RotHorizontal1");
	float y = Input.GetAxis("RotVertical1");
	
 	if (x != 0.0f || y != 0.0f) {
		angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector2(-angle + 90, 90);
	}

		//fires
	if (Input.GetButtonDown("Fire1")) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
		}
	if (primaryWeapon == bullet && Input.GetButtonDown ("Switch")) {
		primaryWeapon = rocket;
		print ("rocket equiped");
		}

	else if (primaryWeapon == rocket && Input.GetButtonDown ("Switch")) {
		primaryWeapon = bullet;
		print ("bullet equiped");
		}
	}
}