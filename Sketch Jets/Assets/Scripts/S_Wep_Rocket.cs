using UnityEngine;
using System.Collections;

public class S_Wep_Rocket : MonoBehaviour {


	public float bltSpd = 20;


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.AddForce (this.transform.up * rigidbody2D.mass * bltSpd);
	}
}
