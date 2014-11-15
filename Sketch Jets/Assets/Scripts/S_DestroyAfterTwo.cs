using UnityEngine;
using System.Collections;

public class S_DestroyAfterTwo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
