using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointShow : MonoBehaviour {
	public GameObject ball;
	// Use this for initialization
	void Start () {
		if (ball == null) {
			ball = GameObject.Find ("Ball");
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.FindChild ("Point1").GetComponent<Text> ().text = ball.GetComponent<BallEvent> ().bluePoint.ToString ();
		transform.FindChild ("Point2").GetComponent<Text> ().text = ball.GetComponent<BallEvent> ().redPoint.ToString ();
	}


}
