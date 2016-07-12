using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class ForwardButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler{
	public GameObject player;
	int playerLastState;

	public bool PressDown;

	public UnityEvent onPress = new UnityEvent ();
	public UnityEvent onRealease = new UnityEvent ();
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		if (player == null) {
			//不同按钮控制不同角色
			if (transform.name == "BTRT") {
				player = GameObject.Find ("Player1");
			}
			if (transform.name == "BTLT") {
				player = GameObject.Find ("Player2");
			}
			if (transform.name == "BTRD") {
				player = GameObject.Find ("Player3");
			}
			if (transform.name == "BTLD") {
				player = GameObject.Find ("Player4");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (PressDown) {
			player.GetComponent<Player> ().state = 0;
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (player != null) {
			playerLastState = player.GetComponent<Player> ().state;
			PressDown = true;
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (player != null) {
			player.GetComponent<Player> ().state = playerLastState * -1;
			PressDown = false;
		}
		onRealease.Invoke ();
	}

	public void OnPointerExit(PointerEventData eventData) {
		PressDown = false;
		onRealease.Invoke ();
	}
}
