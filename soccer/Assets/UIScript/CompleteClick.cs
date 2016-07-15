using UnityEngine;
using System.Collections;

//setting中complete按钮事件
public class CompleteClick : MonoBehaviour {
	public GameObject panel1;
	public GameObject panel2;
	// Use this for initialization
	void Start () {
		if (panel1 == null)
			panel1 = GameObject.Find ("Panel");
		if (panel2 == null)
			panel2 = GameObject.Find ("Panel2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		panel1.SetActive (true);
		panel2.SetActive (false);
	}
}
