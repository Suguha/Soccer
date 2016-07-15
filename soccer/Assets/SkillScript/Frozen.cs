using UnityEngine;
using System.Collections;

public class Frozen : MonoBehaviour {
	// Use this for initialization
	void Start () {
		freeze ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void freeze() {
		for (int i = 1; i < 5; i++) {
			GameObject temp = GameObject.Find ("Player" + i.ToString ());
			if (temp.name != this.name)
				temp.GetComponent<Player> ().frozen = true;
		}
		Invoke ("reFreeze", 3);
	}

	void reFreeze() {
		for (int i = 1; i < 5; i++) {
			GameObject temp = GameObject.Find ("Player" + i.ToString ());
			if (temp.name != this.name)
				temp.GetComponent<Player> ().frozen = false;
		}
	}
}
