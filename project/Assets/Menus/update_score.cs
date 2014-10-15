using UnityEngine;
using System.Collections;

public class update_score : MonoBehaviour {
	private Camera main_camera;

	// Use this for initialization
	void Start () {
		main_camera = GameObject.Find ("Main Camera").camera;
	}

	// call this if the player won the game
	void setSoundPitchHigh() {
		main_camera.audio.pitch = 2;
	}

	// call this if the player lost the game
	void setSoundPitchLow() {
		main_camera.audio.pitch = 0.5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
