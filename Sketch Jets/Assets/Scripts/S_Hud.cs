using UnityEngine;
using System.Collections;

public class S_Hud : MonoBehaviour {

	public Texture RocketTex;
	public Texture MachinegunTex;
	public Texture LaserTex;
	public Texture GaussTex;
	public string P1WeaponEquiped = "MG";
	public string P2WeaponEquiped = "MG";
	public GUIText P1WepEquipedTxt;
	public GUIText P2WepEquipedTxt;
	public GUITexture P1weaponSelected;
	public GUITexture P2weaponSelected;
	public int planetsLeft;
	public GUIStyle guiStyle01;
	public int Score;
	public bool boss = false;

	void Start() {
		guiStyle01.fontSize = 30;
	}

	void Update () {

		GUIweaponSelected();

	}

	void AddScore(int scr){
		Score += scr;
	}

	void PlanetCountStart(int totalplanets){
		planetsLeft = totalplanets;
	}

	void PlanetCapture(){
		planetsLeft --;
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2 - 70, Screen.height * 0.95f, 50, 50), "Planets Left: " + planetsLeft.ToString (), guiStyle01); 
		GUI.Label (new Rect (Screen.width / 2 - 70, Screen.height * 0.90f, 50, 50), "Score: " + Score.ToString (), guiStyle01); 
		if (boss){
			GUI.Label (new Rect (Screen.width / 2 - 70, Screen.height * 0.85f, 50, 50), "Boss Spawned!", guiStyle01); 
		}
	}

	void GUIweaponSelected(){

		//Player1
		if (P1WeaponEquiped == "MG"){
			P1weaponSelected.guiTexture.texture = MachinegunTex;
			P1WepEquipedTxt.text = "BA-CON \n MG";
		}
		if (P1WeaponEquiped == "Rocket"){
			P1weaponSelected.guiTexture.texture = RocketTex;
			P1WepEquipedTxt.text = "BA-CON \n Rockets";
		}
		if (P1WeaponEquiped == "Laser"){
			P1weaponSelected.guiTexture.texture = LaserTex;
			P1WepEquipedTxt.text = "BA-CON \n Lasers";
		}
		if (P1WeaponEquiped == "Gauss"){
			P1weaponSelected.guiTexture.texture = GaussTex;
			P1WepEquipedTxt.text = "BA-CON \n Gauss";
		}

		//Player2
		if (P2WeaponEquiped == "MG"){
			P2weaponSelected.guiTexture.texture = MachinegunTex;
			P2WepEquipedTxt.text = "ST-LHT \n MG";
		}
		if (P2WeaponEquiped == "Rocket"){
			P2weaponSelected.guiTexture.texture = RocketTex;
			P2WepEquipedTxt.text = "ST-LHT \n Rockets";
		}
		if (P2WeaponEquiped == "Laser"){
			P2weaponSelected.guiTexture.texture = LaserTex;
			P2WepEquipedTxt.text = "ST-LHT \n Lasers";
		}
		if (P2WeaponEquiped == "Gauss"){
			P2weaponSelected.guiTexture.texture = GaussTex;
			P2WepEquipedTxt.text = "ST-LHT \n Gauss";
		}
	}

	//Player1
	void EquipMG(){
		P1WeaponEquiped = "MG";
	}

	void EquipRockets(){
		P1WeaponEquiped = "Rocket";
	}

	void EquipLaser(){
		P1WeaponEquiped = "Laser";
	}

	void EquipGauss(){
		P1WeaponEquiped = "Gauss";
	}

	//Player2
	void EquipMG2(){
		P2WeaponEquiped = "MG";
	}
	
	void EquipRockets2(){
		P2WeaponEquiped = "Rocket";
	}
	
	void EquipLaser2(){
		P2WeaponEquiped = "Laser";
	}
	
	void EquipGauss2(){
		P2WeaponEquiped = "Gauss";
	}

	void BossSpawned(){
		boss = true;
	}
}
