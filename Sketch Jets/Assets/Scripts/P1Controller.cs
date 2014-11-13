﻿using UnityEngine;
using System.Collections;

public class P1Controller : MonoBehaviour {

	
public float movSpd = 15.0f;
public float angle;
public float fireSpeed = 0.0f;
public bool rocketPickedUp = false;
public bool laserPickedUp = false;
public bool gaussPickedUp = false;
public float rocketAmmo = 0;
public float laserAmmo = 0;
public float gaussAmmo = 0;

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
		OutOfAmmo();
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
		if (Input.GetButtonDown("Fire1") && rocketAmmo > 0 && primaryWeapon == rocket) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			rocketAmmo --;
		}
		//Fires Machineguns
		if (Input.GetButtonDown("Fire1") && primaryWeapon == machineGun) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
		}
		//Fires Laser
		if (Input.GetButton("Fire1") && laserAmmo > 0 && primaryWeapon == laser) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			laserAmmo --;
		}
		//Fires Gauss
		if (Input.GetButtonDown("Fire1") && gaussAmmo > 0 && primaryWeapon == gauss) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			this.rigidbody2D.AddForce (-bltSpn.transform.up * rigidbody2D.mass * 20 / Time.fixedDeltaTime);
			gaussAmmo --;
		}
	}


	void OutOfAmmo(){
		if (rocketAmmo == 0 && rocketPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG");
			rocketPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
		if (laserAmmo == 0 && laserPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG");
			laserPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
		if (gaussAmmo == 0 && gaussPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG");
			gaussPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
	}

	
	void SwitchWeps(){

		//Equips Rockets
		if (primaryWeapon == machineGun && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets");
		}
		//Equips Lasers from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");
			Camera.main.SendMessage ("EquipLaser");
		}
		//Gauss from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss");
		}
		
		//Machineguns from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == false && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");
			Camera.main.SendMessage ("EquipMG");
		}
		//Lasers from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");
			Camera.main.SendMessage ("EquipLaser");
		}
		//Gauss from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss");
		}
		
		//Machinegun from Lasers
		else if (primaryWeapon == laser && rocketPickedUp == false && gaussPickedUp == false && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
			Camera.main.SendMessage ("EquipMG");
		}
		//Rocket from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == false && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets");
		}
		//Gauss from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss");
		}
		
		//Machinegun from Gauss
		else if (primaryWeapon == gauss && Input.GetButtonDown ("Switch")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
			Camera.main.SendMessage ("EquipMG");
		}
		//Rocket from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets");
		}
		//Laser from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch")) {
			primaryWeapon = laser;
			print ("Laser equiped");	
			Camera.main.SendMessage ("EquipLaser");
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag ==  "Rockets"){
			rocketPickedUp = true;
			rocketAmmo = 5;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag ==  "Lasers"){
			laserPickedUp = true;
			laserAmmo = 100;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag ==  "GaussCannon"){
			gaussPickedUp = true;
			gaussAmmo = 2;
			Destroy (col.gameObject);
		}
	}
}