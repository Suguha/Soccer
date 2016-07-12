using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			player.transform.position += player.transform.forward * 0.1f;
		}
		if (Input.GetKey (KeyCode.S)) {
			player.transform.position -= player.transform.forward * 0.1f;
		}
		if (Input.GetKey (KeyCode.A)) {
			player.transform.position -= player.transform.right * 0.1f;
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.position += player.transform.right * 0.1f;
		}
	}
}
