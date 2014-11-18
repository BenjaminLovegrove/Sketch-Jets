using UnityEngine;
using System.Collections;

public class S_PlanetCapture_PH : MonoBehaviour {
	
	public SpriteRenderer texRenderer;
	public float captureTimer = 5;


	// Use this for initialization
	void Start () {
		texRenderer = GetComponent<SpriteRenderer> ();
		texRenderer.color = Color.red;
	}

	void Update(){
		if (Input.GetButtonDown ("cheat")){
			texRenderer.color = Color.green;
		}
	}

	/*
	void OnTriggerStay (Collider col) {
		captureTimer -= Time.deltaTime;

		if (captureTimer < 0){
			texRenderer.color = Color.green;
		}
	}

	void OnTriggerExit (Collider col) {
		captureTimer = 5;
	}
	*/
}
