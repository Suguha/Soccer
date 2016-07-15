using UnityEngine;
using System.Collections;

public class GoalAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable(){
		GetComponent<AudioSource> ().Play ();
	}

	void OnDisable() {
		//GetComponent<AudioSource> ().Stop ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
