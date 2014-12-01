using UnityEngine;
using System.Collections;

public class S_EnemyBeh_Saucer : MonoBehaviour {

	public float Health = 80;
	public float Damage = 5;
	public ParticleSystem Explosion;
	public GameObject Bullet;
	public GameObject bltSpawner;
	public GameObject weaponDrop;
	public bool laser = false;
	public LineRenderer line;
	public float laserCD = 0;

	public float range;
	public Transform Leader;
	public GameObject[] Players;
	public float maxSpeed = 4;
	public float laserTimer = 0f;

	void Start () {
		
		//Get player objects
		Players = GameObject.FindGameObjectsWithTag ("Player");
		
		//Get shoot range of ship
		range = Random.Range (8, 13);

		line = gameObject.GetComponent<LineRenderer> ();
		line.SetWidth (0.1f, 0.1f);
	}

	void Update () {
		HP();

		float P1Distance = Vector3.Distance (Players [0].transform.position, transform.position);
		float P2Distance = Vector3.Distance (Players [1].transform.position, transform.position);
		
		if (P1Distance < P2Distance){
			Leader = Players[0].transform;
		} else if (P2Distance < P1Distance){
			Leader = Players[1].transform;
		}
		
		AI ();
	}

	void AI(){
		
		//Always look at closest player
		if (laser == false){ 
			Vector3 vectorToTarget = Leader.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
		}
		
		//If out of range move towards player, else stop and shoot player
		if (Vector3.Distance (Leader.transform.position, transform.position) > range && laser == false) {
			Vector2 moveDir = Leader.position - transform.position;
			rigidbody2D.AddForce (moveDir * Time.deltaTime * maxSpeed); //I use max speed in the add force so units with a higher speed also have a higher accell.
			if (rigidbody2D.velocity.sqrMagnitude > maxSpeed){
				rigidbody2D.velocity = (moveDir * Time.deltaTime * maxSpeed);
			}
		} else if (laser == false && laserCD <= 0) {
			rigidbody2D.velocity = (new Vector2 (0, 0));
			//Shoot player
			Vector3 dir = Leader.transform.position - transform.position;
			dir = dir.normalized;
			//GameObject CurrentBlt = (GameObject) Instantiate (Bullet, bltSpawner.transform.position,bltSpawner.transform.rotation);
			//CurrentBlt.rigidbody2D.AddForce (dir * rigidbody2D.mass * 100 / Time.fixedDeltaTime);
			//Destroy (CurrentBlt, 3);
			//mgCooldown = 1f;
			laserTimer = 2f;
			laserCD = 3f;
			laser = true;
		}
		//mgCooldown -= Time.deltaTime;

		if (laser == true) {
			rigidbody2D.velocity = (new Vector2 (0, 0));
			RaycastHit2D hit = Physics2D.Raycast(bltSpawner.transform.position,transform.right);
			if (hit.collider != null){
				hit.collider.gameObject.SendMessage("EnemyLaserHit", SendMessageOptions.DontRequireReceiver);
			}
			line.SetPosition(0, transform.position);
			line.SetPosition(1, bltSpawner.transform.position + (transform.right * 500));
			line.enabled = true;
			laserTimer -= Time.deltaTime;
			if (laserTimer <= 0){
				laser = false;
				line.enabled = false;
			}
		}

		laserCD -= Time.deltaTime;
	}
	
	void HP (){
		if (Health <= 0){
			float dropRNG = Random.Range (0,10);
			if (dropRNG >= 7){
				Instantiate (weaponDrop, this.transform.position, Quaternion.identity);
			}

			Instantiate (Explosion, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
			print ("Saucer Sacrificed!");
			Camera.main.SendMessage ("AddScore", 250);
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag ==  "RocketRound"){
			Instantiate (Explosion, col.transform.position, col.transform.rotation);
			Health -= 25;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag ==  "LaserBeam"){
			Health -= 2;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag ==  "GaussRound"){
			Health -= 100;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag ==  "MachinegunRound"){
			Health -= 5;
			Destroy (col.gameObject);
		}
	}

	void LaserHit(int dmg){
		Health -= dmg;
	}
}
