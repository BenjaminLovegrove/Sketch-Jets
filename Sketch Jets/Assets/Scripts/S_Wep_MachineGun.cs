using UnityEngine;
using System.Collections;

public class S_Wep_MachineGun : MonoBehaviour {

	public float bltSpd = 20;
	
	// Update is called once per frame
	void Start () {
		this.rigidbody2D.AddForce (this.transform.up * rigidbody2D.mass * bltSpd / Time.fixedDeltaTime);
		Destroy (this.gameObject, 2);
	}
}
