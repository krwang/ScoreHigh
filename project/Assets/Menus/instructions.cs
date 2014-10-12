using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {
	public GameObject instructionButton;

	// Use this for initialization
	void Start () {
		instructionButton = GameObject.Find ("Instructions");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (mousePosition);
			if (instructionButton.collider2D.OverlapPoint(mousePosition)) {
				Debug.Log ("Pressed Instructions");
				Application.LoadLevel("instructionScreen");
			}
		}
	}
}
