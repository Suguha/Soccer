using UnityEngine;
using System.Collections;

public class BallEvent : MonoBehaviour {
	//goal1 red x -6.9 z -1.6----1.6
	//goal2 blue x 6.9 z
	Vector3 ballPosition;

	public int redPoint;
	public int bluePoint;

	//一回合是否结束
	public bool roundEnd;
	public bool gameEnd;

	// Use this for initialization
	void Start () {
		redPoint = 0;
		bluePoint = 0;
		roundEnd = false;
		gameEnd = false;
		ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		ballPosition = transform.position;
		//Debug.Log (transform.GetComponent<Rigidbody> ().velocity.magnitude);
		//if (transform.GetComponent<Rigidbody>().velocity.magnitude)
		check ();
	}

	void check() {
		//一回合结束，reset
		if (gameEnd == true) {
			return;
		}
		if (redPoint == 5 || bluePoint == 5) {
			gameEnd = true;
		}
		if (roundEnd == true) {
			return;
		}
		if (float.Parse(ballPosition.x.ToString("#0.0")) == 6.9f && (float.Parse(ballPosition.z.ToString("#0.0")) > -1.6f && float.Parse(ballPosition.z.ToString("#0.0")) < 1.6f)) {
			bluePoint++;
			roundEnd = true;
		}
		if (float.Parse(ballPosition.x.ToString("#0.0")) == -6.9f && (float.Parse(ballPosition.z.ToString("#0.0")) > -1.6f && float.Parse(ballPosition.z.ToString("#0.0")) < 1.6f)) {
			redPoint++;
			roundEnd = true;
		}
	}

	public void resetPoint() {
		redPoint = 0;
		bluePoint = 0;
	}
}
