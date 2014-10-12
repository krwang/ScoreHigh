using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {
	public GameObject quitButton;
	
	// Use this for initialization
	void Start () {
		quitButton = GameObject.Find ("Quit To Menu");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (mousePosition);
			if (quitButton.collider2D.OverlapPoint(mousePosition)) {
				Debug.Log ("Pressed Quit");
				Application.LoadLevel("startScreen");
			}
		}
	}
}
