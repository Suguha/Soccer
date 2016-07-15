using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointShow : MonoBehaviour {
	public GameObject ball;
	public GameObject goal;
	// Use this for initialization
	void Start () {
		if (ball == null) {
			ball = GameObject.Find ("Ball");
		}
		if (goal == null)
			goal = GameObject.Find ("Goal");
		goal.SetActive (false);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.FindChild ("Point1").GetComponent<Text> ().text = ball.GetComponent<BallEvent> ().bluePoint.ToString ();
		transform.FindChild ("Point2").GetComponent<Text> ().text = ball.GetComponent<BallEvent> ().redPoint.ToString ();
		if (ball.GetComponent<BallEvent> ().roundEnd == true && ball.GetComponent<BallEvent> ().gameEnd == false) {
			goal.SetActive (true);
		} else {
			goal.SetActive (false);
		}
	}


}
