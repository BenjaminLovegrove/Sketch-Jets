using UnityEngine;
using System.Collections;

public class S_Hud : MonoBehaviour {

	public Texture RocketTex;
	public Texture MachinegunTex;
	public Texture LaserTex;
	public Texture GaussTex;
	public GUIText WepEquipedTxt;
	public string WeaponEquiped = "MG";
	public GUITexture weaponSelected;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		GUIweaponSelected();

	}

	void GUIweaponSelected(){

		if (WeaponEquiped == "MG"){
			weaponSelected.guiTexture.texture = MachinegunTex;
			WepEquipedTxt.text = "MG";
		}
		if (WeaponEquiped == "Rocket"){
			weaponSelected.guiTexture.texture = RocketTex;
			WepEquipedTxt.text = "Rockets";
		}
		if (WeaponEquiped == "Laser"){
			weaponSelected.guiTexture.texture = LaserTex;
			WepEquipedTxt.text = "Lasers";
		}
		if (WeaponEquiped == "Gauss"){
			weaponSelected.guiTexture.texture = GaussTex;
			WepEquipedTxt.text = "Gauss";
		}
	}

	void EquipMG(){
		WeaponEquiped = "MG";
	}

	void EquipRockets(){
		WeaponEquiped = "Rocket";
	}

	void EquipLaser(){
		WeaponEquiped = "Laser";
	}

	void EquipGauss(){
		WeaponEquiped = "Gauss";
	}
}
