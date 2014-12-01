using UnityEngine;
using System.Collections;

public class S_PlanetCapture_PH : MonoBehaviour {
	
	public SpriteRenderer texRenderer;
	public float captureTimer = 15;
	public bool captured = false;


	// Use this for initialization
	void Start () {
		texRenderer = GetComponent<SpriteRenderer> ();
		texRenderer.color = Color.red;
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Player"){
				captureTimer -= Time.deltaTime;
			if (captured == false){
				Camera.main.SendMessage ("AddScore", 100 * Time.deltaTime);
			}
		}

		if (captureTimer < 0 && captured == false){
			texRenderer.color = Color.green;
			captured = true;
			Camera.main.SendMessage("PlanetCapture");
		}
	}
	/* Didn't like this without a way to make it not so fiddley.
	void OnTriggerExit2D (Collider2D col) {
		captureTimer = 5;
	}
	*/
}
