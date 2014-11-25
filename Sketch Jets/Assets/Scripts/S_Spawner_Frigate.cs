using UnityEngine;
using System.Collections;

public class S_Spawner_Frigate : MonoBehaviour {

	
	public GameObject Frigate;
	public float frigateCD = 8;
	
	void Update () {
		frigateCD -= Time.deltaTime;
		
		if (frigateCD <= 0){
			Instantiate (Frigate, transform.position, transform.rotation);
			frigateCD = 8;
		}
	}
}
