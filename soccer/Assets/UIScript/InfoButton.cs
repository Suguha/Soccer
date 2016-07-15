using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoButton : MonoBehaviour {
	public GameObject panel1;
	public GameObject textPanel;
	// Use this for initialization
	void Start () {
		if (panel1 == null)
			panel1 = GameObject.Find ("Panel");
		if (textPanel == null)
			textPanel = GameObject.Find ("TextPanel");
		textPanel.transform.FindChild ("Text").GetComponent<RectTransform> ().sizeDelta = GameObject.Find("InitUI").GetComponent<RectTransform> ().sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		panel1.SetActive (!panel1.activeSelf);
		textPanel.SetActive (!textPanel.activeSelf);
	}
}
