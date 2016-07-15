using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingData : MonoBehaviour {
	//setting data，保存数据，挂在settingpanel
	public struct PlayerData {
		int color;
		int runSpeed;
		int RotateSpeed;
		int Skill;

		public PlayerData(int c,int r1,int r2, int s){
			color = c;
			runSpeed = r1;
			RotateSpeed = r2;
			Skill = s;
		}

		public int getColor() {
			return color;
		}

		public int getRunSpeed() {
			return runSpeed;
		}

		public int getRotateSpeed() {
			return RotateSpeed;
		}

		public int getSkill() {
			return Skill;
		}
	}
	public PlayerData[] playerSetting = new PlayerData[4];

	string _name = "PlayerSetting";
	string skin = "SkinValue";
	string run = "RunSpeedValue";
	string rotate = "RotateSpeedValue";
	string skill = "SkillValue";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable() {
		for (int i = 1; i < 5; i++) {
			Transform temp = transform.FindChild (_name + i.ToString ());
			int tempSkin = temp.FindChild (skin).GetComponent<Dropdown> ().value + 1;
			int tempRun = temp.FindChild (run).GetComponent<Dropdown> ().value + 1;
			int tempRotate = temp.FindChild (rotate).GetComponent<Dropdown> ().value + 1;
			int tempSkill = temp.FindChild (skill).GetComponent<Dropdown> ().value + 1;
			playerSetting [i - 1] = new PlayerData (tempSkin, tempRun, tempRotate, tempSkill);
		}
	}
}
