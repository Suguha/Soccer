using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject player;
	public float rotateSpeed;
	public float runSpeed;
	public int state;
	public bool force = false;
	// Use this for initialization
	void Start () {
		rotateSpeed = 1f;
		runSpeed = 20f;
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0 && force == false) {
			player.GetComponent<Rigidbody> ().AddForce (transform.forward * runSpeed);
		} else if (force == false) {
			rotate (state);
		} else {
		}
	}

	void rotate(int s){
		Vector3 r = player.transform.rotation.eulerAngles;
		r.y += rotateSpeed * s;
		player.transform.rotation = Quaternion.Euler (r);
	}
}
