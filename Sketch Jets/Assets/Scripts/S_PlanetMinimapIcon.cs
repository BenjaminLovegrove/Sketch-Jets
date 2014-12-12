using UnityEngine;
using System.Collections;

public class S_PlanetMinimapIcon : MonoBehaviour {

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
		}
		
		if (captureTimer < 0 && captured == false){
			texRenderer.color = Color.green;
			captured = true;
		}
	}
}
