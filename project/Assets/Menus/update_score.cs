using UnityEngine;
using System.Collections;

public class update_score : MonoBehaviour {
	private Camera main_camera;
	private TextMesh text;
	
	// Use this for initialization
	void Start () {
		main_camera = GameObject.Find ("Main Camera").camera;
		text = GetComponent<TextMesh> ();

		int score = PlayerPrefs.GetInt ("Win/Lose");
		if (score == -1) {
			text.text = "You Failed!";
			setSoundPitchLow();
		} else {
			text.text = "You survived the week with score " + score;
			setSoundPitchHigh();
		}
	}

	// call this if the player won the game
	void setSoundPitchHigh() {
		main_camera.audio.pitch = 2f;
	}

	// call this if the player lost the game
	void setSoundPitchLow() {
		main_camera.audio.pitch = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
