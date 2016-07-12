using UnityEngine;
using System.Collections;

public class WallRInit : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//wall.transform.Translate (c.GetComponent<Camera> ().ScreenToWorldPoint (new Vector3(Screen.width, 0, 0)).x / 2f, wall.transform.position.y, wall.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision t)
	{
		if (t.gameObject.tag == "Player" || t.gameObject.name == "Ball") {
			if (t.gameObject.tag == "Player") {
				t.gameObject.GetComponent<Player> ().force = true;
			}
			if (transform.gameObject.name == "WallU") {
				t.gameObject.GetComponent<Rigidbody> ().AddForce (0, 0, -500);
			}
			if (transform.gameObject.name == "WallD") {
				t.gameObject.GetComponent<Rigidbody> ().AddForce (0, 0, 500);
			}
			if (transform.gameObject.name == "WallL") {
				t.gameObject.GetComponent<Rigidbody> ().AddForce (500, 0, 0);
			}
			if (transform.gameObject.name == "WallR") {
				t.gameObject.GetComponent<Rigidbody> ().AddForce (-500, 0, 0);
			}
		}
	}

	void OnCollisionExit(Collision t) {
		if (t.gameObject.tag == "Player") {
			t.gameObject.GetComponent<Player> ().force = false;
		}
	}
}
