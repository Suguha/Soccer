using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	RaycastHit hit;
	int lastState;
	bool mul = false;
	// Use this for initialization
	void Start () {
		lastState = GetComponent<Player> ().state;
	}
	
	// Update is called once per frame
	void Update () {
		Physics.Raycast (transform.position, transform.forward, out hit);
		//Debug.Log (hit.point);
		//Debug.Log (hit.transform.gameObject.layer);
		//Debug.DrawLine (transform.position, hit.point, Color.red);
		if (hit.transform.gameObject.layer == 8 && GetComponent<Player>().frozen == false) {
			GetComponent<Player> ().state = 0;
			mul = true;
			return;
		} else {
			if (mul == true) {
				GetComponent<Player> ().state = lastState * -1;
				mul = false;
			}
			lastState = GetComponent<Player> ().state;
		}
	}
}
