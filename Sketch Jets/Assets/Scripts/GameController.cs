﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject Boss;
	public GameObject bossSpwnPos;
	public float bossNum = 0;
	public GameObject[] planets;
	public int planetsLeft;
	public float P1RegenCD = 4;
	public float P2RegenCD = 4;

	// Use this for initialization
	void Start () {
		P1healthBarLength = 300;  
		P2healthBarLength = 300; 
		planets = GameObject.FindGameObjectsWithTag ("PlanetCapture");
		planetsLeft = planets.Length;
		Camera.main.SendMessage ("PlanetCountStart", planetsLeft);
	}
	
	// Update is called once per frame
	void Update () {
		BossSpawn();
		AdjustCurrentHealth(0);
		Death();

		P1RegenCD -= Time.deltaTime;
		P2RegenCD -= Time.deltaTime;

		if (P1RegenCD <= 0 && P1Health < 100){
			P1Health += 0.4f;
		}

		if (P2RegenCD <= 0 && P2Health < 100){
			P2Health += 0.4f;
		}

	}

	void Death (){
		if (P1Health <= 0){
			Application.LoadLevel (0);
		}
		if (P2Health <= 0){
			Application.LoadLevel (0);
		}
	}

	void P1Damage(float dmg){
		P1Health -= dmg;
		P1RegenCD = 7;
	}
	void P2Damage(float dmg){
		P2Health -= dmg;
		P2RegenCD = 7;
	}

	void PlanetCapture(){
		planetsLeft --;
	}

	void BossSpawn(){
		if(planetsLeft <= 0 && bossNum < 1){
			Instantiate (Boss, bossSpwnPos.transform.position, bossSpwnPos.transform.rotation);
			bossNum ++;
			Camera.main.SendMessage ("BossSpawned");
		}
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
		GUI.BeginGroup (new Rect (Screen.width-300,0, P2healthBarLength,32));
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, P2Health / P2maxHealth * P2healthBarLength, 32));
		
		// Draw the foreground image
		GUI.Box (new Rect (0,0,P2healthBarLength,32), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}

	public void AdjustCurrentHealth(int adj){
		
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
