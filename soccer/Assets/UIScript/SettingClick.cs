using UnityEngine;
using System.Collections;

public class SettingClick : MonoBehaviour {
	public GameObject panel;
	public GameObject settingPanel;
	// Use this for initialization
	void Start () {
		if (panel == null)
			panel = GameObject.Find ("Panel");
		if (settingPanel == null)
			settingPanel = GameObject.Find ("SettingPanel");
		settingPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick() {
		settingPanel.SetActive (true);
		panel.SetActive (false);
	}
}
