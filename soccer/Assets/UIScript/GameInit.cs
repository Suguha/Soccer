using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameInit : MonoBehaviour {
	//4个player的pos
	Vector3[] initPos = { new Vector3 (3.15f, 0.5f, 2f), new Vector3 (-3.15f, 0.5f, 2f), new Vector3 (3.15f, 0.5f, -2f), new Vector3 (-3.15f, 0.5f, -2f) };

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
	}
	// Update is called once per frame
	void Update () {
		if (ball.GetComponent<BallEvent> ().roundEnd == false) {
			endTime = Time.time;
		} else {
			if (Time.time - endTime > 2.0f) {
				ball.transform.position = new Vector3 (0f, 0.5f, 0f);
				ball.GetComponent<Rigidbody> ().Sleep ();
				ball.GetComponent<Rigidbody> ().WakeUp ();
				for (int i = 0; i < playerNumber; i++) {
					GameObject player = GameObject.Find ("Player" + (i + 1).ToString ());
					player.transform.position = initPos [i];
				}
				ball.GetComponent<BallEvent> ().roundEnd = false;
			}
		}
	}

	void GameReset() {
		ball.GetComponent<BallEvent> ().resetPoint ();
		if (initUI == null)
			initUI = GameObject.Find ("Begin");
		if (initUI != null) {
			AI = initUI.GetComponent<InitUI> ().getAI ();
			playerNumber = initUI.GetComponent<InitUI> ().getPlayerNumber ();
			for (int i = 0; i < playerNumber; i++) {
				GameObject player = Instantiate (Resources.Load ("Prefab/Player" + (i + 1).ToString ()) as GameObject);
				player.name = "Player" + (i + 1).ToString ();
				player.transform.position = initPos [i];
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
