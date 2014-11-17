using UnityEngine;
using System.Collections;

public class S_PlanetCapture_PH : MonoBehaviour {
	
	public SpriteRenderer renderer;
	public float captureTimer = 5;


	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		renderer.color = Color.red;
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider col) {
		captureTimer -= Time.deltaTime;

		if (captureTimer < 0){
			renderer.color = Color.green;
		}
	}

	void OnTriggerExit (Collider col) {
		captureTimer = 5;
	}
}
