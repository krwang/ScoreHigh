using UnityEngine;
using System.Collections;

public class play_again : MonoBehaviour {
	public GameObject playAgainButton;

	// Use this for initialization
	void Start () {
		playAgainButton = GameObject.Find ("Play Again");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (mousePosition);
			if (playAgainButton.collider2D.OverlapPoint(mousePosition)) {
				Debug.Log ("Pressed Play Again");
				Application.LoadLevel("test");
			}
		}
	}
}
