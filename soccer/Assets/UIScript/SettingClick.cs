using UnityEngine;
using System.Collections;

public class SettingClick : MonoBehaviour {
	public GameObject panel;
	bool slide;
	// Use this for initialization
	void Start () {
		if (panel == null)
			GameObject.Find ("Panel");
		slide = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (slide == true) {
			panel.transform.Translate (-650 * Time.deltaTime, 0, 0);
		}
	}

	public void OnClick() {
		slide = true;
	}
}
