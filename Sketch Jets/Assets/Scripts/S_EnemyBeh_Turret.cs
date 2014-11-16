using UnityEngine;
using System.Collections;

public class S_EnemyBeh_Turret : MonoBehaviour {
	
	Transform Leader;
	public GameObject Bullet;
	public GameObject bltSpawn;
	public float MinDistance = 10;
	public float MaxDistance = 20;
	public float Health = 20;
	Transform myTransform;
	public float rotationSpeed = 3;
	public bool run = true;
	public ParticleSystem Explosion;
	
	
	//declare player as leader
	void Start () {
		StartCoroutine (DoStuff());
	}
	
	void Update () {

		Leader = GameObject.FindGameObjectWithTag("Player").transform;
		if (Health <= 0){
			Instantiate (Explosion, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
		}

		AI();
	}

	//face leader
	void AI()
	{
		if (Vector3.Distance (Leader.position, this.transform.position) < 15)
		{
			Vector3 vectorToTarget = Leader.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

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

	IEnumerator DoStuff() { 
	
		while (run = true){
			const float minimumWaitTime = 0f; 
			const float maximumWaitTime = 3f; 
			yield return new WaitForSeconds(Random.Range(minimumWaitTime, maximumWaitTime));

			if (Vector3.Distance (Leader.position, this.transform.position) < 15)
			{
				GameObject CurrentBlt = (GameObject) Instantiate (Bullet, bltSpawn.transform.position, bltSpawn.transform.rotation);
				CurrentBlt.rigidbody2D.AddForce (bltSpawn.transform.up * rigidbody2D.mass * 20 / Time.fixedDeltaTime);
				Destroy (CurrentBlt, 3);
			}
		}
	}
}
