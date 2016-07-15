using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScript : MonoBehaviour {
	public GameObject ball;
	int count ;
	// Use this for initialization
	void Start () {
		if (ball == null)
			ball = GameObject.Find ("Ball");
		count = 0;
	}

	void OnEnable() {
		this.GetComponent<Text> ().text = "";
		count = 0;
	}
	// Update is called once per frame
	void Update () {
		if (ball.GetComponent<BallEvent> ().redPoint == 5) {
			this.GetComponent<Text> ().text = "红色赢了!";
			this.GetComponent<Text> ().color = new Color (255, 0, 0);
			count++;
			if (count == 1)
				GetComponent<AudioSource> ().Play ();
		}
		if (ball.GetComponent<BallEvent> ().bluePoint == 5) {
			this.GetComponent<Text> ().text = "蓝色赢了!";
			this.GetComponent<Text> ().color = new Color (0, 0, 255);
			count++;
			if (count == 1)
				GetComponent<AudioSource> ().Play ();
		}
	}
}
