using UnityEngine;
using System.Collections;

public class S_Spawner_Saucer : MonoBehaviour {

	
	public GameObject Saucer;
	public float saucerCD = 35;
	
	void Update () {
		saucerCD -= Time.deltaTime;
		
		if (saucerCD <= 0){
			Instantiate (Saucer, transform.position, transform.rotation);
			saucerCD = 35;
		}
	}
}
