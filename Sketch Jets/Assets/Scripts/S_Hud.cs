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


	void Update () {

		GUIweaponSelected();

	}

	void PlanetCountStart(int totalplanets){
		planetsLeft = totalplanets;
	}

	void PlanetCapture(){
		planetsLeft --;
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
}
