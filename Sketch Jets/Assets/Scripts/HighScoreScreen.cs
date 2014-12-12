using UnityEngine;
using System.Collections;

public class HighScoreScreen : MonoBehaviour {

	public int[] HighScores = new int[10];
	public float minTimer = 2;
	public GUIStyle guiStyle01;


	void Start () {
		guiStyle01.normal.textColor = Color.white;
		//Get Highscores
		for (int i = 0; i < 9; i++){
			HighScores[i] = PlayerPrefs.GetInt(i.ToString());
		}
	}

	void Update(){
		minTimer -= Time.deltaTime;

		if (Input.GetButtonDown("Fire1") && minTimer <= 0){
			Application.LoadLevel(0);
		}
	}

	void OnGUI () {
		GUI.Label (new Rect (Screen.width / 2 - 25, Screen.height * .3f, 200, 500), "1....." + HighScores [0] + "\n2....." + HighScores [1] + "\n3....." + HighScores [2] + "\n4....." + HighScores [3] + "\n5....." + HighScores [4] + "\n6....." + HighScores [5] + "\n7....." + HighScores [6] + "\n8....." + HighScores [7] + "\n9....." + HighScores [8] + "\n10....." + HighScores [9], guiStyle01);
		GUI.Box (new Rect (Screen.width /2 - 110, Screen.height *.3f - 40, 200, 500), "HighScores");
		if (minTimer <= 0){
			GUI.Label (new Rect(Screen.width /2 - 70, Screen.height * .8f, 200,50), "Hit FIRE to continue...");
		}
	}
}
