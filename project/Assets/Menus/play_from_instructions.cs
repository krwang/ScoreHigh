using UnityEngine;
using System.Collections;

public class play_from_instructions : MonoBehaviour {
	public GameObject startButton;
	
	// Use this for initialization
	void Start () {
		startButton = GameObject.Find ("Play");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (mousePosition);
			if (startButton.collider2D.OverlapPoint(mousePosition)) {
				Debug.Log ("Pressed Start");
				Application.LoadLevel("test");
			}
		}
	}
}
