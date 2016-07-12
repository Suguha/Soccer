using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//挂在initUI的button上
public class InitUI : MonoBehaviour {
	public GameObject initUI;
	public GameObject controlUI;
	int playerNumber;
	bool AI;
	// Use this for initialization
	void Start () {
		if (initUI == null)
			GameObject.Find ("InitUI");
		if (controlUI == null)
			GameObject.Find ("ControlUI");
		controlUI.GetComponent<GameInit> ().SetAllActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		playerNumber = GameObject.Find("Num").GetComponent<Dropdown> ().value + 1;
		AI = GameObject.Find("AI").GetComponent<Toggle> ().isOn;
		controlUI.GetComponent<GameInit> ().SetAllActive (true);
		initUI.SetActive (false);
	}

	public int getPlayerNumber(){
		return playerNumber;
	}

	public bool getAI() {
		return AI;
	}
}
