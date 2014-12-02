using UnityEngine;
using System.Collections;

public class S_BossBeh : MonoBehaviour {

	public float Health = 25;
	public float Damage = 5;
	public ParticleSystem Explosion;
	public GameObject Bullet;
	public float mgCooldown;
	
	public float range;
	public Transform Leader;
	public GameObject[] Players;
	public float maxSpeed = 8;
	
	void Start () {
		
		//Get player objects
		Players = GameObject.FindGameObjectsWithTag ("Player");
		
		//Get shoot range of ship
		range = Random.Range (9, 15);
		
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
		Vector3 vectorToTarget = Leader.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
		
		//If out of range move towards player, else stop and shoot player
		if (Vector3.Distance (Leader.transform.position, transform.position) > range) {
			Vector2 moveDir = Leader.position - transform.position;
			if (rigidbody2D.velocity.sqrMagnitude < maxSpeed){
				rigidbody2D.AddForce (moveDir * Time.deltaTime * maxSpeed); //I use max speed in the add force so units with a higher speed also have a higher accell.
			}
		} else if (mgCooldown <= 0) {
			rigidbody2D.velocity = (new Vector2 (0, 0));
			//Shoot Player
			Vector3 dir = Leader.transform.position - transform.position;
			dir = dir.normalized;
			GameObject CurrentBlt = (GameObject) Instantiate (Bullet, transform.position,transform.rotation);
			CurrentBlt.rigidbody2D.AddForce (dir * rigidbody2D.mass * 10 / Time.fixedDeltaTime);
			Destroy (CurrentBlt, 7);
			mgCooldown = 1f;
		}

		mgCooldown -= Time.deltaTime;
	}
	
	void HP (){
		if (Health <= 0){
			Instantiate (Explosion, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
			print ("Boss dead!");
			Application.LoadLevel (Application.loadedLevel.ToString());
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