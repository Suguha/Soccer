using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : MonoBehaviour {
	public GameObject initUI;
	public GameObject controlUI;
	// Use this for initialization
	void Start () {
		if (initUI == null)
			GameObject.Find ("InitUI");
		if (controlUI == null)
			GameObject.Find ("ControlUI");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		for (int i = 1; i < 5; i++) {
			GameObject temp = GameObject.Find ("Player" + i.ToString ());
			if (temp != null)
				Destroy (temp);
		}
		initUI.SetActive (true);
		controlUI.GetComponent<GameInit> ().SetAllActive (false);
	}
}
