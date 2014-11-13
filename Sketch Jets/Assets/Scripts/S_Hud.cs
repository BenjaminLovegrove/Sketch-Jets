using UnityEngine;
using System.Collections;

public class S_Hud : MonoBehaviour {

	public Texture RocketTex;
	public Texture MachinegunTex;
	public Texture LaserTex;
	public Texture GaussTex;
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
		}
		if (WeaponEquiped == "Rocket"){
			weaponSelected.guiTexture.texture = RocketTex;
		}
		if (WeaponEquiped == "Laser"){
			weaponSelected.guiTexture.texture = LaserTex;
		}
		if (WeaponEquiped == "Gauss"){
			weaponSelected.guiTexture.texture = GaussTex;
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
