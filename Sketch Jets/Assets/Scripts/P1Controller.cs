using UnityEngine;
using System.Collections;

public class P1Controller : MonoBehaviour {

	
public float movSpd = 15.0f;
public float angle;
public float fireSpeed = 0.0f;
public bool rocketPickedUp = false;
public bool laserPickedUp = false;
public bool gaussPickedUp = false;

	//Attached Game Objects
public GameObject bltSpn;
public GameObject machineGun;
public GameObject rocket;
public GameObject laser;	
public GameObject gauss;
public GameObject primaryWeapon;




	void Update () {

		Movement();
		Fire();
		SwitchWeps();
	}


	void Movement (){

		Vector3 moveDir = new Vector3 ();
		
		moveDir.x = Input.GetAxis ("Horizontal1");
		moveDir.y = Input.GetAxis ("Vertical1");
		
		this.rigidbody2D.AddForce (moveDir.normalized * movSpd);
		
		float x = Input.GetAxis("RotHorizontal1");
		float y = Input.GetAxis("RotVertical1");
		
		if (x != 0.0f || y != 0.0f) {
			angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle);
		}
	}


	void Fire(){

		//Fires Rockets
		if (Input.GetButtonDown("Fire1") && primaryWeapon == rocket) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
		}
		//Fires Machineguns
		if (Input.GetButtonDown("Fire1") && primaryWeapon == machineGun) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
		}
		//Fires Laser
		if (Input.GetButton("Fire1") && primaryWeapon == laser) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
		}
		if (Input.GetButtonDown("Fire1") && primaryWeapon == gauss) {

			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			this.rigidbody2D.AddForce (-bltSpn.transform.up * rigidbody2D.mass * 20 / Time.fixedDeltaTime);
		}
	}

	
	void SwitchWeps(){

		//Equips Rockets
		if (primaryWeapon == machineGun && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
		}
		//Equips Lasers from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");
		}
		//Gauss from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
		}
		
		//Machineguns from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == false && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");
		}
		//Lasers from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");
		}
		//Gauss from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
		}
		
		//Machinegun from Lasers
		else if (primaryWeapon == laser && rocketPickedUp == false && gaussPickedUp == false && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
		}
		//Rocket from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == false && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
		}
		//Gauss from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
		}
		
		//Machinegun from Gauss
		else if (primaryWeapon == gauss && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
		}
		//Rocket from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");	
		}
		//Laser from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");	
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag ==  "Rockets"){
			rocketPickedUp = true;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag ==  "Lasers"){
			laserPickedUp = true;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag ==  "GaussCannon"){
			gaussPickedUp = true;
			Destroy (col.gameObject);
		}
	}
}