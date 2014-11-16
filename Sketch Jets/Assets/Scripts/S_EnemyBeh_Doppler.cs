using UnityEngine;
using System.Collections;

public class S_EnemyBeh_Doppler : MonoBehaviour {


	public float Health = 50;
	public float Damage = 5;
	public ParticleSystem Explosion;


	void Update () {
		HP();
	}

	void HP (){
		if (Health <= 0){
			Instantiate (Explosion, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
			print ("Doppler Down");
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
}
