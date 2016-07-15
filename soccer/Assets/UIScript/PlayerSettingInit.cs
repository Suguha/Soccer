using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSettingInit : MonoBehaviour {
	public GameObject initUI;
	// Use this for initialization
	void Start () {
		if (initUI == null)
			initUI = GameObject.Find ("InitUI");
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (initUI.GetComponent<RectTransform> ().sizeDelta.x / 4f, initUI.GetComponent<RectTransform> ().sizeDelta.y);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
