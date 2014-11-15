using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float P1Health = 100f;
	public float P2Health = 100f;
	public GameObject Player1;
	public bool needRevive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Death();
	}

	void Death (){
		if (P1Health <= 0 && needRevive == false){
			print ("Player1. You Have Died");
			needRevive = true;
		}
	}
	void P1TenDamage(){
		P1Health -= 10;
	}
}
