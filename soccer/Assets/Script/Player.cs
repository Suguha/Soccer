using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	/// <summary>
	/// The player basic data.
	/// </summary>
	public int rotateSpeed;
	public int runSpeed;

	public int state;
	public bool force;
	public bool frozen;
	public bool AI = false;
	// Use this for initialization
	void Start () {
		//GetComponent<MeshRenderer> ().materials [0] = Resources.Load ("/Material/PlayerSkin" + skin.ToString ()) as Material;
		state = 1;
	}
	void OnEnable() {
		force = false;
		frozen = false;
	}
	// Update is called once per frame
	void Update () {
		if (state == 0 && force == false && frozen == false) {
			GetComponent<Rigidbody> ().AddForce (transform.forward * runSpeed * GetComponent<Rigidbody> ().mass);
		} else if (force == false && frozen == false) {
			rotate (state);
		} else {
		}
	}

	void rotate(int s){
		Vector3 r = transform.rotation.eulerAngles;
		r.y += rotateSpeed * s;
		transform.rotation = Quaternion.Euler (r);
	}
}
