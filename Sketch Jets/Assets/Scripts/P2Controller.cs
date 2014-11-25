using UnityEngine;
using System.Collections;

public class P2Controller : MonoBehaviour {
	
	
public float movSpd = 15.0f;
public float angle;
public float fireSpeed = 0.0f;
public bool rocketPickedUp = false;
public bool laserPickedUp = false;
public bool gaussPickedUp = false;
public float rocketAmmo = 0;
public float laserAmmo = 0;
public float gaussAmmo = 0;
public string currentAmmo;
public string MGAmmo = "Unlimited";
public GameObject Explosion;
public 	float mgCooldown;
public GUIText AmmoText;
public float rocketCD;
public float gaussCD;
public float gaussStay;
public LineRenderer line;


	//Attached Game Objects
public GameObject bltSpn;
public GameObject machineGun;
public GameObject rocket;
public GameObject laser;	
public GameObject gauss;
public GameObject primaryWeapon;
public GameObject PickupSound;
public Object MuzzleFlash;

	void Start(){
		currentAmmo = MGAmmo;
		line = gameObject.GetComponent<LineRenderer> ();
	}

	void Update () {

		AmmoText.text = currentAmmo;
		rocketCD -= Time.deltaTime;
		gaussCD -= Time.deltaTime;
		gaussStay -= Time.deltaTime;

		if (gaussStay <= 0) {
			line.enabled = false;
		}

		GUIDebug();
		Movement();
		Fire();
		SwitchWeps();
		OutOfAmmo();
	}


	void Movement (){

		Vector3 moveDir = new Vector3 ();
		
		moveDir.x = Input.GetAxis ("Horizontal2");
		moveDir.y = Input.GetAxis ("Vertical2");
		
		this.rigidbody2D.AddForce (moveDir.normalized * movSpd);
		
		float x = Input.GetAxis("RotHorizontal2");
		float y = Input.GetAxis("RotVertical2");
		
		if (x != 0.0f || y != 0.0f) {
			angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle);
		}
	}


	void Fire(){

		//Fires Rockets
		if (Input.GetButtonDown("Fire2") && rocketAmmo > 0 && primaryWeapon == rocket) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			rocketAmmo --;
			currentAmmo = rocketAmmo.ToString();
			rocketCD = 1;
		}
		//Fires Machineguns
		if (Input.GetButton("Fire2") && primaryWeapon == machineGun && mgCooldown < 0) {
			Instantiate (primaryWeapon, bltSpn.transform.position, bltSpn.transform.rotation);
			Object MF = Instantiate (MuzzleFlash, transform.position, transform.rotation);
			Destroy (MF, 0.05f);
			mgCooldown = 0.2f;
			currentAmmo = MGAmmo;
		}
		mgCooldown -= Time.deltaTime;
		//Fires Laser
		if (Input.GetButton("Fire2") && laserAmmo > 0 && primaryWeapon == laser) {
			RaycastHit2D hit = Physics2D.Raycast(bltSpn.transform.position,transform.right);
			if (hit.collider != null){
				hit.collider.gameObject.SendMessage("LaserHit", 2, SendMessageOptions.DontRequireReceiver);
			}
			line.SetPosition(0, transform.position);
			line.SetPosition(1, bltSpn.transform.position + (transform.right * 500));
			line.enabled = true;
			laserAmmo -= Time.deltaTime;
			currentAmmo = laserAmmo.ToString();
			if (laserAmmo < 0){
				laserAmmo = 0;
			}
		} else {
			line.enabled = false;
			if (laserAmmo < 0){
				laserAmmo = 0;
			}
		}
		
		//Fires Gauss
		if (primaryWeapon == gauss){
			if (Input.GetButtonDown("Fire2") && gaussAmmo > 0 && primaryWeapon == gauss && gaussCD <= 0) {
				gaussCD = 2;
				gaussStay = 0.5f;
				gaussAmmo --;
				this.rigidbody2D.AddForce (-bltSpn.transform.up * rigidbody2D.mass * 20 / Time.fixedDeltaTime);
				line.SetWidth (0.5f, 0.5f);
				RaycastHit2D[] hits = Physics2D.RaycastAll(bltSpn.transform.position,transform.right);
				foreach (RaycastHit2D hit in hits){
					if (hit.collider != null){
						hit.collider.gameObject.SendMessage("LaserHit", 100, SendMessageOptions.DontRequireReceiver);
					}
				}
				line.SetPosition(0, transform.position);
				line.SetPosition(1, bltSpn.transform.position + (transform.right * 500));
				line.enabled = true;
				laserAmmo -= Time.deltaTime;
				currentAmmo = laserAmmo.ToString();
				if (laserAmmo < 0){
					laserAmmo = 0;
				}
			} else if (gaussStay <= 0) {
				line.enabled = false;
				if (laserAmmo < 0){
					laserAmmo = 0;
				}
			}
		}
		
	}


	void OutOfAmmo(){
		if (rocketAmmo == 0 && rocketPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG2");
			rocketPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
		if (laserAmmo == 0 && laserPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG2");
			laserPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
		if (gaussAmmo == 0 && gaussPickedUp == true){
			primaryWeapon = machineGun;
			Camera.main.SendMessage ("EquipMG2");
			gaussPickedUp = false;
			print ("Out of Ammo. Equiped Machinegun");
		}
	}


	void SwitchWeps(){
		
		//Equips Rockets
		if (primaryWeapon == machineGun && rocketPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets2");
		}
		//Equips Lasers from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = laser;
			print ("Laser equiped");
			Camera.main.SendMessage ("EquipLaser2");
		}
		//Gauss from Machineguns
		else if (primaryWeapon == machineGun && rocketPickedUp == false && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss2");
		}
		
		//Machineguns from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == false && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");
			Camera.main.SendMessage ("EquipMG2");
		}
		//Lasers from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = laser;
			print ("Laser equiped");
			Camera.main.SendMessage ("EquipLaser2");
		}
		//Gauss from Rockets
		else if (primaryWeapon == rocket && laserPickedUp == false && gaussPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss2");
		}
		
		//Machinegun from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == false && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
			Camera.main.SendMessage ("EquipMG2");
		}
		//Rocket from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == false && rocketPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets2");
		}
		//Gauss from Lasers
		else if (primaryWeapon == laser && gaussPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = gauss;
			print ("Gauss equiped");
			Camera.main.SendMessage ("EquipGauss2");
		}
		
		//Machinegun from Gauss
		else if (primaryWeapon == gauss && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = machineGun;
			print ("Machinegun equiped");	
			Camera.main.SendMessage ("EquipMG2");
		}
		//Rocket from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = rocket;
			print ("Rocket equiped");
			Camera.main.SendMessage ("EquipRockets2");
		}
		//Laser from Gauss
		else if (primaryWeapon == gauss && rocketPickedUp == false && laserPickedUp == true && Input.GetButtonDown ("Switch2")) {
			primaryWeapon = laser;
			print ("Laser equiped");	
			Camera.main.SendMessage ("EquipLaser2");
		}
	}

	void GUIDebug() {
		if (primaryWeapon == machineGun){
			currentAmmo = MGAmmo.ToString();
		}
		if (primaryWeapon == laser){
			currentAmmo = laserAmmo.ToString();
		}
		if(primaryWeapon == rocket){
			currentAmmo = rocketAmmo.ToString();
		}
		if(primaryWeapon == gauss){
			currentAmmo = gaussAmmo.ToString();
		}
	}


	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag ==  "EnmyMG"){
			Camera.main.SendMessage ("P2Damage", 5);
			Instantiate (Explosion, col.transform.position, col.transform.rotation);
			Destroy (col.gameObject);
		}
		
		if (col.gameObject.tag ==  "EnmyRocket"){
			Camera.main.SendMessage ("P2Damage", 25);
			Instantiate (Explosion, col.transform.position, col.transform.rotation);
			Destroy (col.gameObject);
		}
		
		if (col.gameObject.tag ==  "Rockets"){
			rocketPickedUp = true;
			rocketAmmo += 5;
			PickupSound.SendMessage ("PickupSound");
			Destroy (col.gameObject);
		}
		
		if (col.gameObject.tag ==  "Lasers"){
			laserPickedUp = true;
			laserAmmo += 100;
			PickupSound.SendMessage ("PickupSound");
			Destroy (col.gameObject);
		}
		
		if (col.gameObject.tag ==  "GaussCannon"){
			gaussPickedUp = true;
			gaussAmmo += 2;
			PickupSound.SendMessage ("PickupSound");
			Destroy (col.gameObject);
		}
	}
}