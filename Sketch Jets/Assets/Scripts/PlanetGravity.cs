using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour {

	public float planetSize = 8.0f;
	public float gravPull;
	public Vector2 direction;

	void OnTriggerStay2D (Collider2D col) {

		gravPull = Vector3.Distance (transform.position, col.transform.position);
		direction = transform.position - col.transform.position;

		col.rigidbody2D.AddForce (direction * planetSize / gravPull);

		if (col.tag == "MachinegunRound"){
			col.rigidbody2D.AddForce (direction * planetSize * 20 / gravPull);
		}
	}
}
