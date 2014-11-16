using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float P1Health = 100f;
	public float P2Health = 100f;
	public GameObject Player1;
	public GameObject Player2;
	public bool P1needRevive = false;
	public bool P2needRevive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Death();
	}

	void Death (){
		if (P1Health <= 0 && P1needRevive == false){
			print ("Player1. You Have Died");
			P1needRevive = true;
		}
		if (P2Health <= 0 && P2needRevive == false){
			print ("Player2. You Have Died");
			P2needRevive = true;
		}
	}

	void P1TenDamage(){
		P1Health -= 10;
	}
	void P2TenDamage(){
		P2Health -= 10;
	}
}
