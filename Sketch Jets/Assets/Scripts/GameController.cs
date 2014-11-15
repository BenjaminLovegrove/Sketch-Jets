using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float P1Health = 100f;
	public float P2Health = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void P1TenDamage(){
		P1Health -= 10;
	}
}
