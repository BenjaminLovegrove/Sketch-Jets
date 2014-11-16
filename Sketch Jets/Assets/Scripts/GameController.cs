using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int P1maxHealth = 100;
	public int P2maxHealth = 100;
	public float P1Health = 100f;
	public float P2Health = 100f;
	public GameObject Player1;
	public GameObject Player2;
	public bool P1needRevive = false;
	public bool P2needRevive = false;
	public Texture2D fgImage; 
	public float P1healthBarLength;
	public float P2healthBarLength;

	// Use this for initialization
	void Start () {
		P1healthBarLength = 300;  
		P2healthBarLength = 300; 
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
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


	void OnGUI () {

		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0, P1healthBarLength,32));
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, P1Health / P1maxHealth * P1healthBarLength, 32));
		
		// Draw the foreground image
		GUI.Box (new Rect (0,0,P1healthBarLength,32), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();


		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0, P2healthBarLength,32));
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, P2Health / P2maxHealth * P2healthBarLength, 32));
		
		// Draw the foreground image
		GUI.Box (new Rect (0,0,P2healthBarLength,32), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}

	public void AddjustCurrentHealth(int adj){
		
		P1Health += adj;
		P2Health += adj;

		if(P1Health < 0){
			P1Health = 0;
		}
		if(P2Health < 0){
			P2Health = 0;
		}
		if(P1Health > P1maxHealth){
			P1Health = P1maxHealth;
		}
		if(P2Health > P2maxHealth){
			P2Health = P2maxHealth;
		}
		P1healthBarLength = 300 * (P1Health / (float)P1maxHealth);
		P2healthBarLength = 300 * (P2Health / (float)P2maxHealth);
	}
}
