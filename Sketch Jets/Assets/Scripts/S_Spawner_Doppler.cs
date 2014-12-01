using UnityEngine;
using System.Collections;

public class S_Spawner_Doppler : MonoBehaviour {


	public GameObject Doppler;
	public float dopplerCD = 22;

	void Update () {
		dopplerCD -= Time.deltaTime;

		if (dopplerCD <= 0){
			Instantiate (Doppler, transform.position, transform.rotation);
			dopplerCD = Random.Range (20,45);
		}
	}
}
