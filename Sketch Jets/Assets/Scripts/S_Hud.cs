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
	public GUIStyle guiStyle02;
	public static int Score;
	public bool boss = false;
	public P1Controller p1;
	public P2Controller p2;
	public  float instructions = 10f;

	void Start() {
		guiStyle01.fontSize = 30;
		guiStyle02.fontSize = 20;
		guiStyle02.normal.textColor = Color.white;
		P1WepEquipedTxt.anchor = TextAnchor.MiddleLeft;
		P2WepEquipedTxt.anchor = TextAnchor.MiddleRight;

	}

	void Update () {

		GUIweaponSelected();

		instructions -= Time.deltaTime;

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
		if (instructions > 0){
			GUI.Box (new Rect (Screen.width *.59f, Screen.height *.565f, 450,250), "instructions");
			GUI.Label (new Rect ( Screen.width *.6f, Screen.height *.6f, 200,200), "Capture the planets by hoving to lure the boss! \n \n If either player dies you lose! \n Avoid damage to regenerate health. \n \n Movement and aiming - Analog Sticks \n Fire - Right trigger \n Change weapon - Left trigger", guiStyle02);
		}
	}

	void GUIweaponSelected(){

		//Player1
		if (P1WeaponEquiped == "MG"){
			P1weaponSelected.guiTexture.texture = MachinegunTex;
			P1WepEquipedTxt.text = "BA-CON - Machine Gun";
		}
		if (P1WeaponEquiped == "Rocket"){
			P1weaponSelected.guiTexture.texture = RocketTex;
			P1WepEquipedTxt.text = "BA-CON - Rockets - "  + p1.rocketAmmo.ToString("F1");
		}
		if (P1WeaponEquiped == "Laser"){
			P1weaponSelected.guiTexture.texture = LaserTex;
			P1WepEquipedTxt.text = "BA-CON - Lasers - "  + p1.laserAmmo.ToString("F1");
		}
		if (P1WeaponEquiped == "Gauss"){
			P1weaponSelected.guiTexture.texture = GaussTex;
			P1WepEquipedTxt.text = "BA-CON - GAUSS - "  + p1.gaussAmmo.ToString("F1");
		}

		//Player2
		if (P2WeaponEquiped == "MG"){
			P2weaponSelected.guiTexture.texture = MachinegunTex;
			P2WepEquipedTxt.text = "ST-LHT - Machine Gun";
		}
		if (P2WeaponEquiped == "Rocket"){
			P2weaponSelected.guiTexture.texture = RocketTex;
			P2WepEquipedTxt.text = "ST-LHT - Rockets - "  + p2.rocketAmmo.ToString("F1");
		}
		if (P2WeaponEquiped == "Laser"){
			P2weaponSelected.guiTexture.texture = LaserTex;
			P2WepEquipedTxt.text = "ST-LHT - Lasers - "  + p2.laserAmmo.ToString("F1");
		}
		if (P2WeaponEquiped == "Gauss"){
			P2weaponSelected.guiTexture.texture = GaussTex;
			P2WepEquipedTxt.text = "ST-LHT - GAUSS - "  + p2.gaussAmmo.ToString("F1");
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

	void EndGame (){
		//Something for highscores and ending the game etc
	}
}
