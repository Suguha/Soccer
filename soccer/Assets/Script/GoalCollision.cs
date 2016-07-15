using UnityEngine;
using System.Collections;

public class GoalCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnCollisionEnter(Collision t) {
		if (t.gameObject.tag == "Player") {
			t.gameObject.GetComponent<Player> ().force = true;
			t.gameObject.GetComponent<Rigidbody> ().AddForce (t.transform.forward * -300f * t.gameObject.GetComponent<Rigidbody> ().mass);
		}
	}

	void OnCollisionExit(Collision t) {
		if (t.gameObject.tag == "Player") {
			t.gameObject.GetComponent<Player> ().force = false;
		}
	}
}
