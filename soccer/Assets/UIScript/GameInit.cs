using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameInit : MonoBehaviour {
	//4个player的pos
	Vector3[] initPos = { new Vector3 (3.15f, 0.5f, 2f), new Vector3 (-3.15f, 0.5f, 2f), new Vector3 (3.15f, 0.5f, -2f), new Vector3 (-3.15f, 0.5f, -2f) };
	//setting data
	public GameObject setting;

	//获取游戏设置信息
	public GameObject initUI;   //获取initUI的button
	int playerNumber;
	bool AI;

	//gameobject控制
	public GameObject BTRT;
	public GameObject BTRD;
	public GameObject BTLT;
	public GameObject BTLD;
	public GameObject result;
	public GameObject ball;

	//时间控制
	float endTime;
	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		
	}

	void OnEnable() {
		GameReset ();
		///debug information
		/// debug setting data 是否成功传入
		/*
		for (int i = 0; i < 4; i++) {
			Debug.Log ("player" + i.ToString () + " color: " + setting.GetComponent<SettingData> ().playerSetting [i].getColor ().ToString ());
			Debug.Log ("player" + i.ToString () + " run: " + setting.GetComponent<SettingData> ().playerSetting [i].getRunSpeed().ToString ());
			Debug.Log ("player" + i.ToString () + " rotate: " + setting.GetComponent<SettingData> ().playerSetting [i].getRotateSpeed().ToString ());
			Debug.Log ("player" + i.ToString () + " skill: " + setting.GetComponent<SettingData> ().playerSetting [i].getSkill ().ToString ());
		}
		*/
	}
	// Update is called once per frame
	void Update () {
		if (ball.GetComponent<BallEvent> ().gameEnd == true)
			return;
		if (ball.GetComponent<BallEvent> ().roundEnd == false) {
			endTime = Time.time;
		} else {
			if (Time.time - endTime > 3.0f) {
				ball.transform.position = new Vector3 (0f, 0.5f, 0f);
				ball.GetComponent<Rigidbody> ().Sleep ();
				ball.GetComponent<Rigidbody> ().WakeUp ();
				for (int i = 0; i < playerNumber; i++) {
					GameObject player = GameObject.Find ("Player" + (i + 1).ToString ());
					player.transform.position = initPos [i];
					player.GetComponent<Rigidbody> ().Sleep ();
					player.GetComponent<Rigidbody> ().WakeUp ();
					if (setting.GetComponent<SettingData> ().playerSetting [i].getSkill () == 3) {
						player.GetComponent<Frozen> ().freeze ();
					}
				}
				ball.GetComponent<BallEvent> ().roundEnd = false;
			}
		}
	}

	void GameReset() {
		ball.GetComponent<BallEvent> ().resetPoint ();
		if (initUI == null)
			initUI = GameObject.Find ("Begin");
		else {
			AI = initUI.GetComponent<InitUI> ().getAI ();
			playerNumber = initUI.GetComponent<InitUI> ().getPlayerNumber ();
			ball.transform.position = new Vector3 (0f, 0.5f, 0f);
			ball.GetComponent<Rigidbody> ().Sleep ();
			ball.GetComponent<Rigidbody> ().WakeUp ();
			for (int i = 0; i < playerNumber; i++) {
				GameObject player = Instantiate (Resources.Load ("Prefab/Player" + (i + 1).ToString ()) as GameObject);
				player.name = "Player" + (i + 1).ToString ();
				player.GetComponent<Renderer> ().material = Resources.Load ("Material/PlayerSkin" + setting.GetComponent<SettingData> ().playerSetting [i].getColor ().ToString ()) as Material;
				if (setting.GetComponent<SettingData> ().playerSetting [i].getSkill () == 2) {
					player.GetComponent<Rigidbody> ().mass = 100;
				} else if (setting.GetComponent<SettingData> ().playerSetting [i].getSkill () == 3) {
					player.AddComponent<Frozen> ();
				}
				player.GetComponent<Player> ().runSpeed = setting.GetComponent<SettingData> ().playerSetting [i].getRunSpeed () * 20;
				player.GetComponent<Player> ().rotateSpeed = setting.GetComponent<SettingData> ().playerSetting [i].getRotateSpeed ();
				player.transform.position = initPos [i];
			}
			if (AI) {
				if (playerNumber >= 2) {
					GameObject.Find ("Player2").GetComponent<Player> ().AI = true;
					GameObject.Find ("Player2").AddComponent<AI> ();
				}
				if (playerNumber >= 4) {
					GameObject.Find ("Player4").GetComponent<Player> ().AI = true;
					GameObject.Find ("Player4").AddComponent<AI> ();
				}
			}
		}
	}

	public void SetAllActive(bool t) {
		transform.gameObject.SetActive (t);
		result.SetActive (t);
		BTRT.SetActive (t);
		BTLD.SetActive (t);
		BTLT.SetActive (t);
		BTRD.SetActive (t);
	}
}
