using UnityEngine;
using System.Collections;

public class S_EnemyBeh_Doppler : MonoBehaviour {


	public float Health = 50;
	public float Damage = 5;


	void Update () {
		HP();
	}

	void HP (){
		if (Health <= 0){
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag ==  "RocketRound"){
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
